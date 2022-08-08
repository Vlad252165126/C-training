# C-training
polymorphism and inheritance is doc file begin 4-1
    internal class Program
    {
        class Document
        {
            public virtual void Openfile()
            {
                Console.WriteLine("Doc is open");
            }
            public virtual void Savefile()
            {
                Console.WriteLine("Doc is save");
            }
            public virtual void Editfile()
            {
                Console.WriteLine("you can edit file only is Expert version");
            }
        }
        class DocumentPro : Document
        {
            public override void Openfile()
            {
                Console.WriteLine("Doc is open");
            }
            public override void Savefile()
            {
                Console.WriteLine("Doc is save");
            }
            public override void Editfile()
            {
                Console.WriteLine("you can edit file only is Expert version");
            }
        }
        class DocumentExp : Document
        {
            public override void Openfile()
            {
                Console.WriteLine("Doc is open");
            }
            public override void Savefile()
            {
                Console.WriteLine("Doc is save");
            }
            public override void Editfile()
            {
                Console.WriteLine("doc is edit");
            }
        }

        private const string PRO_LICENCE = "111";
        private const string EXP_LICENCE = "222";
      
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a licence key");
            var licence = Console.ReadLine();
            Document doc;
            switch(licence)
            {
                case PRO_LICENCE: doc = new DocumentPro(); break;
                case EXP_LICENCE: doc = new DocumentExp(); break;
                default: doc = new Document(); break;
            }
            while(true)
            {
                Console.WriteLine("Enter a command 0/s/e/q: ");
                switch(Console.ReadLine())
                {
                    case "0": doc.Openfile(); break;
                    case "s": doc.Savefile();break;
                    case "e": doc.Editfile();break;
                    case "q":return;
                }
            }
            Console.ReadKey();
        }
