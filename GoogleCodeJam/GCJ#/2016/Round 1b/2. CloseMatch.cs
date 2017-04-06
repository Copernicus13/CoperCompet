using System;

namespace GoogleCodeJam._2016.Round1b
{
    public class CloseMatch
    {
        public CloseMatch()
        {
            int T = int.Parse(Console.ReadLine());

            for (int nbCase = 1; nbCase <= T; ++nbCase)
            {
                string str = Console.ReadLine();
                string C2 = str.Split(' ')[0];
                string J2 = str.Split(' ')[1];

                char[] C = C2.ToCharArray();
                char[] J = J2.ToCharArray();

                for (int i = 0; i < C.Length; ++i)
                {
                    int a, b;
                    if (C[i] == '?' && J[i] == '?')
                    {
                        if (i == 0 ||
                            int.Parse(string.Join(string.Empty, C).Substring(0, i)) == int.Parse(string.Join(string.Empty, J).Substring(0, i)))
                        {
                            if (i != C.Length - 1 && int.TryParse(string.Join(string.Empty, C).Substring(i + 1, 1), out a) && int.TryParse(string.Join(string.Empty, J).Substring(i + 1, 1), out b) &&
                                a < b)
                            {
                                C[i] = '1';
                                J[i] = '0';
                            }
                            else if (i != C.Length - 1 && int.TryParse(string.Join(string.Empty, C).Substring(i + 1, 1), out a) && int.TryParse(string.Join(string.Empty, J).Substring(i + 1, 1), out b) &&
                                a > b)
                            {
                                C[i] = '0';
                                J[i] = '1';
                            }
                            else
                            {
                                C[i] = '0';
                                J[i] = '0';
                            }
                        }
                        else if (int.Parse(string.Join(string.Empty, C).Substring(0, i)) < int.Parse(string.Join(string.Empty, J).Substring(0, i)))
                        {
                            C[i] = '9';
                            J[i] = '0';
                        }
                        else
                        {
                            C[i] = '0';
                            J[i] = '9';
                        }
                    }
                    else if (C[i] == '?')
                    {
                        if (i == 0 || int.Parse(string.Join(string.Empty, C).Substring(0, i)) == int.Parse(string.Join(string.Empty, J).Substring(0, i)))
                            C[i] = J[i];
                        else if (int.Parse(string.Join(string.Empty, C).Substring(0, i)) < int.Parse(string.Join(string.Empty, J).Substring(0, i)))
                            C[i] = '9';
                        else if (int.Parse(string.Join(string.Empty, C).Substring(0, i)) > int.Parse(string.Join(string.Empty, J).Substring(0, i)))
                            C[i] = '0';
                    }
                    else if (J[i] == '?')
                    {
                        if (i == 0 || int.Parse(string.Join(string.Empty, C).Substring(0, i)) == int.Parse(string.Join(string.Empty, J).Substring(0, i)))
                            J[i] = C[i];
                        else if (int.Parse(string.Join(string.Empty, C).Substring(0, i)) < int.Parse(string.Join(string.Empty, J).Substring(0, i)))
                            J[i] = '9';
                        else if (int.Parse(string.Join(string.Empty, C).Substring(0, i)) > int.Parse(string.Join(string.Empty, J).Substring(0, i)))
                            J[i] = '0';
                    }
                }

                //int res1 = int.Parse(string.Join(string.Empty, C));
                //int res2 = int.Parse(string.Join(string.Empty, J));
                //int res3 = int.Parse(string.Join(string.Empty, C2));
                //int res4 = int.Parse(string.Join(string.Empty, J2));
                //int res5 = int.Parse(string.Join(string.Empty, C2));
                //int res6 = int.Parse(string.Join(string.Empty, J2));

                //if (Math.Abs(res1 - res2) < Math.Abs(res3 - res4))
                //{
                //    Console.WriteLine(string.Format("Case #{0}: {1} {2}", nbCase,
                //        string.Join(string.Empty, C), string.Join(string.Empty, J)));
                //}
                //else if (Math.Abs(res1 - res2) > Math.Abs(res3 - res4))
                //{
                //    Console.WriteLine(string.Format("Case #{0}: {1} {2}", nbCase,
                //        string.Join(string.Empty, C2), string.Join(string.Empty, J2)));
                //}
                //else
                //{
                //    if (res1 < res3)
                //        Console.WriteLine(string.Format("Case #{0}: {1} {2}", nbCase,
                //            string.Join(string.Empty, C), string.Join(string.Empty, J)));
                //    else if (res2 < res3)
                //        Console.WriteLine(string.Format("Case #{0}: {1} {2}", nbCase,
                //            string.Join(string.Empty, C2), string.Join(string.Empty, J2)));
                //    else if (res2 < res4)
                //        Console.WriteLine(string.Format("Case #{0}: {1} {2}", nbCase,
                //            string.Join(string.Empty, C), string.Join(string.Empty, J)));
                //    else
                //        Console.WriteLine(string.Format("Case #{0}: {1} {2}", nbCase,
                //            string.Join(string.Empty, C2), string.Join(string.Empty, J2)));
                //}

                Console.WriteLine(string.Format("Case #{0}: {1} {2}", nbCase,
                    string.Join(string.Empty, C), string.Join(string.Empty, J)));
            }
        }
    }
}
