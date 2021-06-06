using System;

public class turing
    {
        static public void tape(char[] t)
        {
            System.Console.WriteLine("|");
            foreach (char e in t) { System.Console.Write("| " + e + " "); }
            System.Console.WriteLine("|");
        }

        static public void print(int i, char[] t, int s, char m)
        {
            switch (m)
            {
                case 'R':
                    i++;
                    break;
                case 'L':
                    i--;
                    break;
                default:
                    break;
            }
            int j = 0;
            tape(t);
            foreach (char e in t)
            {
                if (i == j) { System.Console.Write("| + "); }
                else { System.Console.Write("|   "); };
                j++;
            }
            System.Console.Write("|");
            System.Console.Write(" Step: " + s);
            System.Console.WriteLine();
        }

        static public void copy(char[] t)
        {
            int i = 0; int s = 0;
            foreach (char e in t)
            {
                if (i < 10) { System.Console.Write("| " + i++ + " "); }
                else { System.Console.Write("| " + i++); };
            }
            //init
            print(i=0, t, s, '0');
            q0(t, i, s);
            if (t[i] == '1') { t[i] = '^'; print(i++, t, s++, 'R'); };
            
            System.Console.WriteLine();
        }

        static public void q0(char[] t, int i, int s)
        {
            while (t[i] == '^') { print(i++, t, s++, 'R'); };
            if (t[i] == '1') { 
                t[i] = 'a'; 
                print(i++, t, s++, 'R'); 
                q1(t, i, s);    
            }
            else if (t[i] == '*') {
                print(i--, t, s++, 'L');
                q7(t, i, s);
            };
        }
        static public void q1(char[] t, int i, int s)
        {
            while (t[i] == '1') { print(i++, t, s++, 'R'); };
            if (t[i] == '*') { 
                print(i++, t, s++, 'R'); 
                q2(t, i, s);    
            };
        }
        static public void q2(char[] t, int i, int s)
        {
            while (t[i] == '^') { print(i++, t, s++, 'R'); };
            if (t[i] == '1') { 
                t[i] = 'b'; 
                print(i++, t, s++, 'R'); 
                q3(t, i, s);
            };

        }
        static public void q3(char[] t, int i, int s)
        {
            while (t[i] == '1' || t[i] == '=') { print(i++, t, s++, 'R'); };
            if (t[i] == '^') { 
                t[i] = '1'; 
                print(i--, t, s++, 'L'); 
                q4(t, i, s);    
            };
            
        }
        static public void q4(char[] t, int i, int s)
        {
            while (t[i] == '1' || t[i] == '=') { print(i--, t, s++, 'L'); };
            if (t[i] == 'b') { 
                print(i++, t, s++, 'R'); 
                q5(t, i, s);
            };

        }
        static public void q5(char[] t, int i, int s)
        {
            if (t[i] == '1') { 
                t[i] = 'b'; 
                print(i++, t, s++, 'R'); 
                q3(t, i, s);
            }
            else if (t[i]== '='){
                t[i]= '=';
                print(i--, t, s++, 'L');
                q6(t,i, s);
            };
        }
        static public void q6(char[] t, int i, int s)
        {
            while (t[i] == 'b') { 
                t[i] = '1';
                print(i--, t, s++, 'L');
            };
            if (t[i] == '*') { print(i--, t, s++, 'L'); };
            while (t[i] == '1') { print(i--, t, s++, 'L'); };
            if (t[i] == 'a') { 
                print(i++, t, s++, 'R'); 
                q0(t, i, s);
            };
        }
        static public void q7(char[] t, int i, int s)
        {
            while (t[i] == 'a') { 
                t[i] = '1'; 
                print(i--, t, s++, 'L'); 
            };

        }
        public static void Main() 
        {
            char[] t1 = { '^','1', '*', '1', '=', '^', '^' };
            char[] t2 = { '^','1', '1', '*', '1', '1', '=', '^', '^', '^', '^' };
            char[] t3 = { '^', '1', '1', '1', '*', '1', '1', '1', '=', '^', '^', '^', '^', '^', '^', '^', '^', '^' };
            char[] t4 = { '^', '1', '1', '1', '*', '1', '1', '=', '^', '^', '^', '^', '^', '^', '^', '^', '^' };
            char[] t5 = { '^', '1', '1', '1', '*', '0', '=', '^', '^', '^', '^', '^', '^', '^', '^', '^' };
            //copy(t1);
            copy(t2);
            //copy(t3);
            //copy(t4);
            //copy(t5);
        }
    }
