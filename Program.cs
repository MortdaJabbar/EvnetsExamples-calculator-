namespace CalculatorWithEvents
{
    internal class Program
    {
        public class CalclatorEventArgs
        {
            public int Number1 { get; }
            public int Number2 { get; }
            public char Op { get; }
            public int Result { get; }
            public CalclatorEventArgs(int Number1, int Number2, int Result, char Op)
            {
                this.Number1 = Number1;
                this.Number2 = Number2;
                this.Result = Result;
                this.Op = Op;
            }

        }
        public class Calclator
        {
            public event EventHandler<CalclatorEventArgs> OnOperationPerformed;

            public void Add(int Number1, int Number2)
            {
                int Result = Number1 + Number2;

                if (OnOperationPerformed != null) { OnOperationPerformed(this, new CalclatorEventArgs(Number1, Number2, Result, '+')); }
            }
            public void Subtrack(int Number1, int Number2)
            {
                int Result = Number1 - Number2;

                if (OnOperationPerformed != null) { OnOperationPerformed(this, new CalclatorEventArgs(Number1, Number2, Result, '-')); }
            }
            public void Multiplay(int Number1, int Number2)
            {
                int Result = Number1 * Number2;

                if (OnOperationPerformed != null) { OnOperationPerformed(this, new CalclatorEventArgs(Number1, Number2, Result, '*')); }
            }
            public void Div(int Number1, int Number2)
            {
                int Result = Number1 / Number2;

                if (OnOperationPerformed != null) { OnOperationPerformed(this, new CalclatorEventArgs(Number1, Number2, Result, '/')); }
            }


        }
        public class Display
        {
            public void Subscribe(Calclator C)
            {
                C.OnOperationPerformed += DisplayOperation;
            }
            public void unSubscribe(Calclator C)
            {
                C.OnOperationPerformed -= DisplayOperation;
            }
            public void DisplayOperation(object sender, CalclatorEventArgs e)
            {
                Console.WriteLine("\nA New Opartaion Performed\n");
                Console.WriteLine($"\nOperationSign: {e.Op}\n");
                Console.WriteLine($"\nMathExp : {e.Number1} {e.Op} {e.Number2} = {e.Result} \n");
            }
        }
        public class Loginfo
        {
            public string LoggerName { get; }
            public Loginfo(string logger) { this.LoggerName = logger; }
            public void StrartLogs(Calclator C)
            {
                C.OnOperationPerformed += LogOperation;
            }
            public void StopLogs(Calclator C)
            {
                C.OnOperationPerformed -= LogOperation;
            }
            private void LogOperation(object sender, CalclatorEventArgs e)
            {
                string logs = $"\n A New Opartaion Performed\n\nOperationSign: {e.Op}\n \n MathExp : {e.Number1} {e.Op} {e.Number2} = {e.Result} \n Date: {DateTime.Now}\n LogedBy:{LoggerName} ";
                File.AppendAllText($"C:\\Users\\User\\Desktop\\Logs.txt", logs);
            }
        }


        static void Main(string[] args)
        {
            Calclator calc = new Calclator();
            Loginfo log = new Loginfo("Mortda");
            Display dsiplay = new Display();
            log.StrartLogs(calc);
            dsiplay.Subscribe(calc);

            calc.Multiplay(5, 2);
            calc.Subtrack(8, 0);
            calc.Div(20, 4);
            calc.Add(40, -4);


        }
    }
}
