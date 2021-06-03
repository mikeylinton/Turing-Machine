using System;

namespace projectturing
{
    public class turing
    {
        static public void tape(char[] t)
        {
            System.Console.WriteLine("|");
            foreach (char e in t) { System.Console.Write("| " + e + " "); }
            System.Console.WriteLine("|");
        }

        static public void print(int i, int m, int n, char[] t, int s)
        {
            int j = 0;
            tape(t);
            foreach (char e in t)
            {
                if (i == j) { System.Console.Write("| + "); }
                else { System.Console.Write("|   "); };
                j++;
            }
            System.Console.Write("|");
            System.Console.Write(" Step: "+s);
            System.Console.WriteLine();
        }

        static public void copy(char[] t)
        {
            int i = 0; int m = 0; int n = 0; int s=0;
            foreach (char e in t)
            {
                if (i < 10) { System.Console.Write("| " + i++ + " "); }
                else { System.Console.Write("| " + i++); };
            }
            print(i=0, m, n, t, s++);
            while (t[i] != '1') { print(i++, m, n, t, s++); };
            while (t[i] == '1') { print(i++, m++, n, t, s++); };
            if (t[i] == '*') { print(i++, m, n, t, s++); };
            while (t[i] == '1') { print(i++, m, n++, t, s++); };
            if (t[i] == '^') { t[i] = '='; print(i, m, n, t, s++); };
            for (int M = 0; M < m; M++)
            {
                for (int N = 0; N < n; N++)
                {
                    i++;
                    t[i] = '1';
                    print(i, m, n, t, s++);
                }
            }
            System.Console.WriteLine();
        }

        public static void Main()
        {
            //char[] t0 = { '^', '*', '^', '^', '^', '^' };
            char[] t1 = { '1', '*', '1', '^', '^', '^' };
            char[] t2 = { '1', '1', '*', '1', '1', '^', '^', '^', '^', '^' };
            char[] t3 = { '1', '1', '1', '*', '1', '1', '1', '^', '^', '^', '^', '^', '^', '^', '^', '^', '^' };

            //copy(t0);
            copy(t1);
            copy(t2);
            copy(t3);
        }
    }
}
