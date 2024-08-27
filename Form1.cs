using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Myst.LexicalAnalysis;
using Aspose.Cells;


namespace Metro1
{
    
    public partial class Form1 : Form
    {
        static string path;
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op_file = new OpenFileDialog();
           
            if(op_file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string text = File.ReadAllText(op_file.FileName);
                    StartButton.Enabled = true;
                    path = op_file.FileName;
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Скорее всего файл не доступен для чтения. Попробуйте выбрать другой файл. ","Не удалось открыть файл", MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                    StartButton.Enabled = false;
                }              
                
            }
        }
        //запятые
        static int amountOfSemicolons = 0;
        static int amountOfComa = 0;
        static int amountOfDot = 0;


        //скобки
        static int amountOfOpenBloks = 0;
        static int amountOfCloseBloks = 0;
        static int amountOfOpen_Left = 0;
        static int amountOfOpen_Right = 0;
        static int amountOfArrayLeft = 0;
        static int amountOfArrayRight = 0;

        //арифмитические
        static int amountOfMinus = 0;
        static int amountOfPlus = 0;
        static int amountOfMod = 0;
        static int amountOfStars = 0;
        static int amountOfDivision = 0;

        // присваивание
        static int amountOfAssignment = 0;
        static int amountOfLet = 0;
        static int amountOfInitialization = 0;

        //сложные арифмитические
        static int amountOfMinus_with_result = 0;
        static int amountOfPlus_with_result = 0;
        static int amountOfMod_with_result = 0;
        static int amountOfStar_with_result = 0;
        static int amountOfDivision_with_result = 0;
        static int amountOfXor_with_result = 0;

        //логические
        static int amountOfNot = 0;
        static int amountOfOr = 0;
        static int amountOfXor = 0;
        static int amountOfAnd = 0;
        static int amountOfLogic_and = 0;
        static int amountOfLogic_or = 0;


        //операции сравнения 
        static int amountOfEquality = 0;
        static int amountOfInequality = 0;
        static int amountOfLess = 0;
        static int amountOfMore = 0;
        static int amountOfLessOrEq = 0;
        static int amountOfMoreOrEq = 0;

        //циклы
        static int amountOfFor = 0;
        static int amountOfDoWhile = 0;
        static int amountOfWhile = 0;
        static int amountOfForeach = 0;

        //ветвление
        static int amountOfIf = 0;
        static int amountOfSwitch = 0;


        //остальные операторы
        static int amountOfOpens = 0;
        static int amountOfFrom= 0;
        static int amountOfMain = 0;
        static int amountOfTransferType = 0;
        static int amountOfHands = 0;
        static int amountOfIn = 0;
        static int amountOfIntSubstit = 0;
        static int amountOfStringSubstit = 0;
        static int amountOfNMarker = 0;


        //консольный ввод-вывод
        static int amountOfConsoleWrite = 0;
        static int amountOfConsoleRead = 0;
        static int amountOfConsoleWriteLine = 0;
        static int amountOfConsoleClear = 0;
        static int amountOfConsoleReadLine = 0;

        private void StartButton_Click(object sender, EventArgs e)
        {
            ShowTableButton.Enabled = false;
            var lexer = new Lexer();
            lexer.AddDefinition(new TokenDefinition(@"if|main|->|from|for|to|do|in|match|_|with|while|open|let", "key_words"));
            lexer.AddDefinition(new TokenDefinition(@"private|public|static|protected|const", "access_modifer"));
            lexer.AddDefinition(new TokenDefinition(@"int|float|var|abstract|string", "type"));
            lexer.AddDefinition(new TokenDefinition(@"printfn", "Console_Write"));
            lexer.AddDefinition(new TokenDefinition(@"\%d", "IntSubstit"));
            lexer.AddDefinition(new TokenDefinition(@"\%s", "StringSubstit"));
            lexer.AddDefinition(new TokenDefinition(@"\\\n", "NewLineMarker"));
            lexer.AddDefinition(new TokenDefinition(@"\|>", "TransferType"));
            lexer.AddDefinition(new TokenDefinition(@"sprintf", "Console_Line_Write"));
            lexer.AddDefinition(new TokenDefinition(@"ReadKey()", "Console_Read_Key"));
            lexer.AddDefinition(new TokenDefinition(@"ReadLine()", "Console_Read_Line"));
            lexer.AddDefinition(new TokenDefinition(@"Clear()", "Console_Clear")); 
            lexer.AddDefinition(new TokenDefinition(@"^return$", "return"));
         
            lexer.AddDefinition(new TokenDefinition(@"\-", "Minus"));
            lexer.AddDefinition(new TokenDefinition(@"\<-", "Assignment"));
            lexer.AddDefinition(new TokenDefinition(@"\*", "Star"));
            lexer.AddDefinition(new TokenDefinition(@"\/", "Division"));
            lexer.AddDefinition(new TokenDefinition(@"\+", "Plus"));
            lexer.AddDefinition(new TokenDefinition(@"\%", "Modulo"));
            //lexer.AddDefinition(new TokenDefinition(@"\***", "Degree"));


            lexer.AddDefinition(new TokenDefinition(@"=", "Initialization"));
            lexer.AddDefinition(new TokenDefinition(@"\==$", "Equality"));
            lexer.AddDefinition(new TokenDefinition(@"\<>", "Inequality"));
            lexer.AddDefinition(new TokenDefinition(@"\not", "Not"));
            lexer.AddDefinition(new TokenDefinition(@"\|\|\|", "Or"));
            lexer.AddDefinition(new TokenDefinition(@"\|", "ForMatch"));
            lexer.AddDefinition(new TokenDefinition(@"\^^^", "Xor"));
            lexer.AddDefinition(new TokenDefinition(@"\&&&", "Bit_And"));
            lexer.AddDefinition(new TokenDefinition(@"\&&", "Logic_And"));
            lexer.AddDefinition(new TokenDefinition(@"\||", "Logic_Or"));
            lexer.AddDefinition(new TokenDefinition(@"\-=", "Minus_with_result"));
            lexer.AddDefinition(new TokenDefinition(@"\+=", "Plus_with_result"));
            lexer.AddDefinition(new TokenDefinition(@"\^=", "Xor_with_result"));
            lexer.AddDefinition(new TokenDefinition(@"\%=", "Mod_with_result"));
            lexer.AddDefinition(new TokenDefinition(@"\/=", "Division_with_result"));
            lexer.AddDefinition(new TokenDefinition(@"\*=", "Star_with_result"));
            lexer.AddDefinition(new TokenDefinition(@"<|>|<=|>=", "Comparsion"));

            lexer.AddDefinition(new TokenDefinition(@"\(", "Open_Left"));
            lexer.AddDefinition(new TokenDefinition(@"\)", "Open_Right"));
            lexer.AddDefinition(new TokenDefinition(@"{", "Open_Block"));
            lexer.AddDefinition(new TokenDefinition(@"}", "Close_Block"));

            lexer.AddDefinition(new TokenDefinition(@"[0-9]+", "integer"));
            lexer.AddDefinition(new TokenDefinition(@"[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?", "double"));
            lexer.AddDefinition(new TokenDefinition(@"[a-zA-Z_]+[a-zA-Z_0-9]*", "id"));
            lexer.AddDefinition(new TokenDefinition(@"'[a-zA-Z_]'", "symbol"));

            lexer.AddDefinition(new TokenDefinition(@"\042[0-9a-zA-Z_ \.\#\,\%\(\)\:\;\?\!\<\>\\\{\}\[\]\/\042\0427]+\042", "string"));
            lexer.AddDefinition(new TokenDefinition(@"\042", "double_quotes"));
            lexer.AddDefinition(new TokenDefinition(@"\0427", "one_quote"));

            lexer.AddDefinition(new TokenDefinition(@"\[", "array_def_left"));
            lexer.AddDefinition(new TokenDefinition(@"\]", "array_def_right"));
            lexer.AddDefinition(new TokenDefinition(@";", "Semicolon"));
      
            lexer.AddDefinition(new TokenDefinition(@",", "Coma"));
            lexer.AddDefinition(new TokenDefinition(@".", "Dot"));
            lexer.AddDefinition(new TokenDefinition(@":", "Colon"));

            StringBuilder sb = new StringBuilder();
            using (StreamReader file_reader = new StreamReader(path))
            {
                // Iterating the file
                while (file_reader.Peek() >= 0)
                {
                    string temp = file_reader.ReadLine();
                    for (int i = 1; i < temp.Length - 1; i++)
                    {
                        if (temp[i] == '/' && temp[i + 1] == '/')
                        {
                            temp = temp.Substring(0, i);
                            break;
                        }
                    }
                    
                    sb.AppendLine(temp);
                }
            }

            using (StreamWriter file_writer = new StreamWriter("new_code.txt"))
            {
                file_writer.WriteLine(sb.ToString());
            }

            string expression = sb.ToString();
            sb.Clear();

            List<Token> list = new List<Token>();
            list.Clear();
            foreach (var token in lexer.Tokenize(expression))
            {
                list.Add(token);

            }

            using (StreamWriter file_writer = new StreamWriter("token_code.txt"))
            {
                foreach (var token in list)
                {
                    file_writer.WriteLine(token.ToString());
                }
            }

            foreach (var token in list)
            {

                //sw.WriteLine(token.ToString());
                switch (token.Type)
                {
                    case "Semicolon":
                        amountOfSemicolons++;
                        break;
                    case "Open_Block":
                        amountOfOpenBloks++;
                        break;
                    case "Close_Block":
                        amountOfCloseBloks++;
                        break;
                    case "Open_Left":
                        amountOfOpen_Left++;
                        break;
                    case "Open_Right":
                        amountOfOpen_Right++;
                        break;
                    case "Initialization":
                        amountOfInitialization++;
                        break;
                    case "array_def_left":
                        amountOfArrayLeft++;
                        break;
                    case "array_def_right":
                        amountOfArrayRight++;
                        break;
                    case "Minus":
                        amountOfMinus++;
                        break;
                    case "Star":
                        amountOfStars++;
                        break;
                    case "Division":
                        amountOfDivision++;
                        break;
                    case "Plus":
                        amountOfPlus++;
                        break;
                    case "Modulo":
                        amountOfMod++;
                        break;
                    case "Assignment":
                        amountOfAssignment++;
                        break;
                    case "Not":
                        amountOfNot++;
                        break;
                    case "Or":
                        amountOfOr++;
                        break;
                    case "Xor":
                        amountOfXor++;
                        break;
                    case "Bit_And":
                        amountOfAnd++;
                        break;
                    case "Logic_And":
                        amountOfLogic_and++;
                        break;
                    case "Logic_Or":
                        amountOfLogic_or++;
                        break;
                    case "Minus_with_result":
                        amountOfMinus_with_result++;
                        break;
                    case "Plus_with_result":
                        amountOfPlus_with_result++;
                        break;
                    case "Xor_with_result":
                        amountOfXor_with_result++;
                        break;
                    case "Mod_with_result":
                        amountOfMod_with_result++;
                        break;
                    case "Division_with_result":
                        amountOfDivision_with_result++;
                        break;
                    case "Star_with_result":
                        amountOfStar_with_result++;
                        break;
                    case "key_words":
                        def_keywords(token);
                        break;
                    case "Console_Write":
                        amountOfConsoleWrite++;
                        break;
                    case "Console_Line_Write":
                        amountOfConsoleWriteLine++;
                        break;
                    case "Console_Read_Key":
                        amountOfConsoleRead++;
                        break;
                    case "Console_Clear":
                        amountOfConsoleClear++;
                        break;
                    case "Console_Read_Line":
                        amountOfConsoleReadLine++;
                        break;
                    case "Coma":
                        amountOfComa++;
                        break;
                    case "Dot":
                        amountOfDot++;
                        break;
                    case "TransferType":
                        amountOfTransferType++;
                        break;
                    case "IntSubstit":
                        amountOfIntSubstit++;
                        break;
                    case "StringSubstit":
                        amountOfStringSubstit++;
                        break;

                    default:
                        def_comparsion(token);
                        break;          


                }
            }
            out_operands(list);
            out_operators();
            
            list.Clear();
            out_table();
            
           // MessageBox.Show("Ваши данные успешно записаны в файл. ", "Анализ выполнен", MessageBoxButtons.OK,
                       // MessageBoxIcon.Information,
                        //MessageBoxDefaultButton.Button1,
                        //MessageBoxOptions.DefaultDesktopOnly);
            if (System.Diagnostics.Process.GetProcessesByName("yandex.exe").Length > 0)
                this.WindowState = FormWindowState.Minimized;
            if (System.Diagnostics.Process.GetProcessesByName("taskmgr.exe").Length > 0)
                this.WindowState = FormWindowState.Minimized;
            StartButton.Enabled = false;
            ShowTableButton.Enabled = true;

        }

        private static void def_keywords(Token token)
        {
            switch (token.Value) 
                      {
                case "for":
                    amountOfFor++;
                    break;
                case "main":
                    amountOfMain++;
                break;
                 case "->":
                    amountOfHands++;
                break;
                case "in":
                    amountOfIn++;
                break;
                case "from":
                    amountOfFrom++;
                break;
                case "let":
                    amountOfLet++;
                    break;                
                case "while":
                    amountOfWhile++;
                    break;
                case "if":
                    amountOfIf++;
                    break;
                case "foreach":
                    amountOfForeach++;
                    break;
                case "match":
                    amountOfSwitch++;
                    break;
                case "open":
                    amountOfOpens++;
                    break;
                case "NewLineMarker":
                    amountOfNMarker++;
                    break;
            }
        }

        private static void def_comparsion(Token token)
        {
            switch (token.Value)
            {
                case "==":
                    amountOfEquality++; break;
                case "<>":
                    amountOfInequality++; break;
                case "<":
                    amountOfLess++; break;
                case ">":
                    amountOfMore++; break;
                case "<=":
                    amountOfLessOrEq++; break;
                case ">=":
                    amountOfMoreOrEq++; break;
            }
        }

        private static void out_operators()
        {
            using (StreamWriter sw = new StreamWriter("operators.txt"))
            {
               
                if (amountOfSemicolons > 0)
                {
                    sw.WriteLine("; {0}", amountOfSemicolons);
                }

                if(amountOfNMarker > 0)
                {
                    sw.WriteLine("\\n {0}", amountOfNMarker);
                }
                if (amountOfComa > 0)
                {
                    sw.WriteLine(", {0}", amountOfComa);
                }

                if (amountOfDot > 0)
                {
                    sw.WriteLine(". {0}", amountOfDot);
                }

                if (amountOfLet > 0)
                {
                    sw.WriteLine("let {0}", amountOfLet);
                }

                if (amountOfWhile > 0)
                {
                    sw.WriteLine("while..do {0}", amountOfWhile);
                }

                if(amountOfIn > 0)
                {
                    sw.WriteLine("in {0}", amountOfIn);
                }

                if (amountOfForeach > 0)
                {
                    sw.WriteLine("foreach.. {0}", amountOfForeach);
                }

                if (amountOfFor > 0)
                {
                    sw.WriteLine("for..do {0}", amountOfFor);
                }

                if (amountOfOpens > 0)
                {
                    sw.WriteLine("open {0}", amountOfOpens);
                }

                if (amountOfIf > 0)
                {
                    sw.WriteLine("if..else {0}", amountOfIf);
                }

                if (amountOfSwitch > 0)
                {
                    sw.WriteLine("match..with.._ {0}", amountOfSwitch);
                }

                if (amountOfConsoleWrite > 0)
                {
                    sw.WriteLine("Printfn {0}", amountOfConsoleWrite);
                }
                if (amountOfConsoleWriteLine > 0)
                {
                    sw.WriteLine("Sprintf {0}", amountOfConsoleWriteLine);
                }

                if (amountOfConsoleClear > 0)
                {
                    sw.WriteLine("Clear() {0}", amountOfConsoleClear);
                }              

                if (amountOfConsoleReadLine > 0)
                {
                    sw.WriteLine("ReadLine() {0}", amountOfConsoleReadLine);
                }

                if (amountOfConsoleRead > 0)
                {
                    sw.WriteLine("ReadKey() {0}", amountOfConsoleRead);
                }

                if (amountOfIntSubstit > 0)
                {
                    sw.WriteLine("%d {0}", amountOfIntSubstit);
                }

                if (amountOfStringSubstit > 0)
                {
                    sw.WriteLine("%s {0}", amountOfStringSubstit);
                }

                if (amountOfHands > 0)
                {
                    sw.WriteLine("-> {0}", amountOfHands);
                }

                if (amountOfTransferType > 0)
                {
                    sw.WriteLine("|> {0}", amountOfTransferType);
                }

                if (amountOfMinus > 0)
                {
                    sw.WriteLine("- {0}", amountOfMinus);
                }

                if (amountOfPlus > 0)
                {
                    sw.WriteLine("+ {0}", amountOfPlus);
                }

                if (amountOfStars > 0)
                {
                    sw.WriteLine("* {0}", amountOfStars);
                }

                if (amountOfMod > 0)
                {
                    sw.WriteLine("% {0}", amountOfMod);
                }

                if (amountOfAssignment > 0)
                {
                    sw.WriteLine("<- {0}", amountOfAssignment);
                }

                if (amountOfMinus_with_result > 0)
                {
                    sw.WriteLine("-= {0}", amountOfMinus_with_result);
                }

                if (amountOfPlus_with_result > 0)
                {
                    sw.WriteLine("+= {0}", amountOfPlus_with_result);
                }

                if (amountOfMod_with_result > 0)
                {
                    sw.WriteLine("%= {0}", amountOfMod_with_result);
                }

                if (amountOfStar_with_result > 0)
                {
                    sw.WriteLine("*= {0}", amountOfStar_with_result);
                }

                if (amountOfDivision_with_result > 0)
                {
                    sw.WriteLine("/= {0}", amountOfMinus_with_result);
                }

                if (amountOfXor_with_result > 0)
                {
                    sw.WriteLine("^= {0}", amountOfMinus_with_result);
                }

                if (amountOfNot > 0)
                {
                    sw.WriteLine("not {0}", amountOfNot);
                }

                if (amountOfOr > 0)
                {
                    sw.WriteLine("||| {0}", amountOfOr);
                }

                if (amountOfXor > 0)
                {
                    sw.WriteLine("^ {0}", amountOfXor);
                }

                if (amountOfAnd > 0)
                {
                    sw.WriteLine("&&& {0}", amountOfAnd);
                }

                if (amountOfLogic_and > 0)
                {
                    sw.WriteLine("&& {0}", amountOfLogic_and);
                }

                if (amountOfLogic_or > 0)
                {
                    sw.WriteLine("|| {0}", amountOfLogic_or);
                }

                if (amountOfEquality > 0)
                {
                    sw.WriteLine("== {0}", amountOfEquality);
                }

                if (amountOfInequality > 0)
                {
                    sw.WriteLine("<> {0}", amountOfInequality);
                }

                if (amountOfLess > 0)
                {
                    sw.WriteLine("< {0}", amountOfLess);
                }

                if (amountOfInitialization > 0)
                {
                    sw.WriteLine("= {0}", amountOfInitialization);
                }

                if (amountOfMore > 0)
                {
                    sw.WriteLine("> {0}", amountOfMore);
                }

                if (amountOfLessOrEq > 0)
                {
                    sw.WriteLine("<= {0}", amountOfLessOrEq);
                }
                if (amountOfMoreOrEq > 0)
                {
                    sw.WriteLine(">= {0}", amountOfMoreOrEq);
                }
            }
        }

        private static void out_operands(List<Token> list)
        {
            List<string> alphabetTable = new List<string>();
            Token[] tkarr = list.ToArray();
            int i = 0;      
            
            int max = tkarr.Length - 1;
            //define variables 
            while (i < max)
            {
                if ((tkarr[i].Type == "id")||(tkarr[i].Type == "string") ||(tkarr[i].Type == "symbol"))
                {
                    string temp = tkarr[i].Value;
                    if (!alphabetTable.Contains(temp))
                    {                      
                        alphabetTable.Add(temp);               
                    }
                }
                else if (tkarr[i].Value == "open")
                {
                    i++;
                    if (tkarr[i].Type == "id")
                    {
                        string temp = tkarr[i].Value;
                        if (!alphabetTable.Contains(temp))
                        {
                            alphabetTable.Add(temp);
                        }
                      
                    }
                }
                i++;
            }

            using (StreamWriter sw = new StreamWriter("operands.txt"))
            {
                foreach (var item in alphabetTable)
                {
                    int amount = 0;
                    string tcurr = "";
                    string substS = "%s";
                    string markerN = "\\n";
                    string substD = "%d";
                    foreach (var token in list)
                    {
                        if (token.Value == item)
                        {
                            amount++;
                            tcurr = token.Type;
                        }
                    }
                    if (amount > 0)
                    {
                        if ((tcurr == "id")|| (tcurr == "string") || (tcurr == "symbol"))
                        {                            
                            string temp = item;
                            while (temp.Contains(markerN))
                            {
                                int index = temp.IndexOf(markerN);
                                temp = temp.Remove(index, markerN.Length);                            
                                amountOfNMarker++;
                            }
                            while (temp.Contains(substS))
                            {
                                int index = temp.IndexOf(substS);
                                temp = temp.Remove(index, substS.Length);                                
                                amountOfStringSubstit++;
                            }
                            while (temp.Contains(substD))
                            {
                                int index = temp.IndexOf(substD);
                                temp = temp.Remove(index, substD.Length);                                
                                amountOfIntSubstit++;
                            }
                            sw.WriteLine("{0}-{1}", temp, amount);
                        } else
                            sw.WriteLine("{0}-{1}", item, amount);
                    }
                }

                alphabetTable.Clear();
                foreach (var token in list)
                {
                    if ((token.Type == "integer") || (token.Type == "double"))
                    {
                        string temp = token.Value;
                        if (!alphabetTable.Contains(temp)) { alphabetTable.Add(temp); }
                    }
                }

                foreach (var item in alphabetTable)
                {
                    int amount = 0;
                    foreach (var token in list)
                    {
                        if (token.Value == item) amount++;
                    }
                    if (amount > 0)
                    {
                        sw.WriteLine("{0}-{1}", item, amount);
                    }
                }
            }
        }

        private static void out_table()
        {
            StringBuilder strings = new StringBuilder();
            int operand_lines = 0;
            int operators_lines = 0;
            using (StreamReader sr = new StreamReader("operands.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    strings.AppendLine(sr.ReadLine() + '-');
                    operand_lines++;
                }
            }

            string[] operand_arr = (strings.ToString()).Split('-');
            Console.WriteLine(operand_arr.Length);
            strings.Clear();

            using (StreamReader sr = new StreamReader("operators.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    strings.AppendLine(sr.ReadLine() + ' ');
                    operators_lines++;
                }
            }
            string[] operators_arr = (strings.ToString()).Split(' ');
            Console.WriteLine(operators_arr.Length);
            strings.Clear();
            int colCount = 6;
            int rowCount = (operators_lines > operand_lines ? operators_lines : operand_lines) + 2;

            Workbook wb = new Workbook();
            Worksheet sheet = wb.Worksheets[0];
            //Название листа (вкладки снизу)
            sheet.Name = "Таблица";
            //Cells cells = sheet.Cells;             

            sheet.Cells["A1"].PutValue("Оператор");
            sheet.Cells[0, 1].PutValue("j");

            sheet.Cells[0, 2].PutValue("F1j");

            sheet.Cells[0, 3].PutValue("i");

            sheet.Cells[0, 4].PutValue("Операнд");

            sheet.Cells[0, 5].PutValue("F2j");
         
            for (int i = 1; i < operators_lines; i++)
            {
                int j = (i - 1) * 2;
                sheet.Cells[i, 0].PutValue(i.ToString() + '.');
                sheet.Cells[i, 1].PutValue(operators_arr[j]);
                sheet.Cells[i, 2].PutValue(operators_arr[j + 1]);
            }

            for (int i = 1; i < operand_lines; i++)
            {
                int j = (i - 1) * 2;
                sheet.Cells[i, 3].PutValue(i.ToString() + '.');
                sheet.Cells[i, 4].PutValue(operand_arr[j]);
                sheet.Cells[i, 5].PutValue(operand_arr[j + 1]);
            }

            int amountOfOperators = 0;
            int amountOfOperands = 0;

            for (int i = 1; i < operand_lines * 2; i += 2)
            {
                amountOfOperands += Int32.Parse(operand_arr[i]);
            }

            for (int i = 1; i < operators_lines * 2; i += 2)
            {
                amountOfOperators += Int32.Parse(operators_arr[i]);
            }
            
            sheet.Cells[(rowCount - 1), 0].PutValue("Кол-во операторов");
            sheet.Cells[rowCount - 1, 3].PutValue("Кол-во операндов");
            sheet.Cells[rowCount - 1, 2].PutValue(amountOfOperators.ToString());
            sheet.Cells[rowCount - 1, 5].PutValue(amountOfOperands.ToString());

            int programDictionary = operators_lines + operand_lines;
            int programLength = amountOfOperands + amountOfOperators;
            int programSize = programLength * (int)Math.Log(programDictionary, 2);


            sheet.Cells[1, 7].PutValue("Словарь программы = " + programDictionary.ToString());
            sheet.Cells[2, 7].PutValue("Длинна программы = " + programLength.ToString());
            sheet.Cells[3, 7].PutValue("Объем программы = " + programSize);
            wb.Save("Excel_Table.xlsx", SaveFormat.Xlsx);

        }

        private void ShowTableButton_Click(object sender, EventArgs e)
        {
            Hide();
            TableForm startform = new TableForm();           
            startform.Show();
        }

   

        private void Exit(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
        
    

