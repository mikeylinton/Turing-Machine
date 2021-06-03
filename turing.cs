using System;

public class turing
{
    static public void tape(char[] t){
            int i = 0;
            
            foreach (char e in t) { 
                if (i<10){System.Console.Write("| " + i++ +" ");}
                else {System.Console.Write("| " + i++);};
            }
            System.Console.WriteLine("|");
            foreach (char e in t) { System.Console.Write("| " + e+" "); }
            System.Console.WriteLine("|");
    }

    static public void print(int i, int m, int n, char[] t){
        int j=0;
        tape(t);
        foreach (char e in t) { 
            if (i==j) { System.Console.Write("| + "); }
            else { System.Console.Write("|   "); };
            j++;
        }
        System.Console.WriteLine("|");
        System.Console.WriteLine();
    }
    
    static public void copy(char[] t){
        int i=0; int m=0; int n=0;
        print(i,m,n,t);
        while (t[i]!='1') { 
            i++;
            print(i,m,n,t);
        }
        while (t[i]=='1') { 
            m++; i++; 
            print(i,m,n,t);
        };
        if (t[i]=='*') { 
            i++; 
            print(i,m,n,t);
        };
        while (t[i]=='1') { 
            n++; i++; 
            print(i,m,n,t);
        };
        if (t[i]=='^') { 
            t[i]='=';
            print(i,m,n,t);
        };
        for (int M=0; M<m;M++){
            for (int N=0; N<n;N++){
                i++;
                t[i]='1';
                print(i,m,n,t);
            }
        }
    }
    
    public static void Main()
    {
        char[] t0 = { '^', '1', '1', '*', '1', '1', '^', '^', '^', '^', '^', '^', '^', '^', '^' };
        char[] t1 = { '^', '1', '*', '0', '^' };
        copy(t1);
    }
}