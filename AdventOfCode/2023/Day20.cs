using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode._2023
{
    /// <summary>
    /// https://adventofcode.com/2023/day/20
    /// </summary>
    public class Day20
    {
        public enum Type
        {
            Broadcast,
            FlipFlop,
            Inverter
        }

        public enum Signal
        {
            Low,
            High,
            None
        }

        public class Module
        {
            public Type Type { get; }
            public bool State { get; private set; }
            public Signal CurrentSignal { get; private set; }
            public Dictionary<string, Signal> LastPulseReceived { get; }

            public Module(char type)
            {
                Type = type switch
                {
                    '%' => Type.FlipFlop,
                    '&' => Type.Inverter,
                    _ => Type.Broadcast
                };
                State = false;
                LastPulseReceived = new Dictionary<string, Signal>();
            }

            public void Activate(Signal input, string moduleName = "")
            {
                switch (Type)
                {
                    case Type.Broadcast:
                        CurrentSignal = input;
                        break;
                    case Type.FlipFlop when input == Signal.Low:
                        State = !State;
                        CurrentSignal = State ? Signal.High : Signal.Low;
                        break;
                    case Type.Inverter:
                        LastPulseReceived[moduleName] = input;
                        CurrentSignal = LastPulseReceived.All(a => a.Value == Signal.High) ? Signal.Low : Signal.High;
                        break;
                    default:
                        CurrentSignal = Signal.None;
                        break;
                }
            }
        }

        private readonly Dictionary<string, Module> _modules;
        private readonly Dictionary<string, List<string>> _workflow;

        public Day20(Part p)
        {
            long result = 0;
            string line;
            _modules = new Dictionary<string, Module>();
            _workflow = new Dictionary<string, List<string>>();

            while (!string.IsNullOrEmpty(line = Console.ReadLine()!))
            {
                string name = line.Split('>')[0][..(line.Split('>')[0].Length - 2)];
                var outputs = line.Split('>')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.TrimEnd(','))
                    .ToList();
                _modules.Add(name[1..], new Module(name[0]));
                _workflow.Add(name[1..], outputs);
            }

            // Initialize LastPulseReceived of Inverters
            foreach (var step in _workflow)
                foreach (string moduleName in step.Value
                             .Where(name => _modules.ContainsKey(name) &&
                                            _modules[name].Type == Type.Inverter &&
                                            !_modules[name].LastPulseReceived.ContainsKey(step.Key)))
                    _modules[moduleName].LastPulseReceived.Add(step.Key, Signal.Low);

            if (p == Part.Part1)
            {
                long nbHigh = 0, nbLow = 0;
                for (int i = 0; i < 1000; ++i)
                {
                    var res = Launch();
                    nbHigh += res.NbHigh;
                    nbLow += res.NbLow;
                }
                result = nbHigh * nbLow;
            }
            else if (p == Part.Part2)
            {
                // My input contains only one parent for rx
                string rxParent = _workflow.Single(w => w.Value.Contains("rx")).Key;
                var rxParentActivators = _modules[rxParent]
                    .LastPulseReceived
                    .Select(s => (s.Key, 0L, false))
                    .ToList();
                long cpt = 0;
                while (rxParentActivators.Any(a => !a.Item3))
                {
                    ++cpt;
                    Launch();
                    for (var j = 0; j < rxParentActivators.Count; ++j)
                    {
                        if (rxParentActivators[j].Item3)
                            continue;
                        rxParentActivators[j] = (
                            rxParentActivators[j].Item1,
                            cpt,
                            _modules[rxParentActivators[j].Item1].CurrentSignal == Signal.High);
                    }
                }
            }
        }

        private (int NbHigh, int NbLow) Launch()
        {
            int nbHigh = 0, nbLow = 1;
            var queue = new Queue<(string Name, Signal SignalSent, string Parent)>();
            queue.Enqueue(("roadcaster", Signal.Low, string.Empty));
            while (queue.Count > 0)
            {
                var currentModule = queue.Dequeue();
                _modules[currentModule.Name].Activate(currentModule.SignalSent, currentModule.Parent);

                foreach (string name in _workflow[currentModule.Name])
                    if (_modules.ContainsKey(name) && _modules[currentModule.Name].CurrentSignal != Signal.None)
                        queue.Enqueue((name, _modules[currentModule.Name].CurrentSignal, currentModule.Name));

                switch (_modules[currentModule.Name].CurrentSignal)
                {
                    case Signal.High:
                        nbHigh += _workflow[currentModule.Name].Count;
                        break;
                    case Signal.Low:
                        nbLow += _workflow[currentModule.Name].Count;
                        break;
                }
            }
            return (nbHigh, nbLow);
        }
    }
}