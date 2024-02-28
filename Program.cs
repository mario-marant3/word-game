public class GlobalVar
{
    public string[] wordList = [];
    public string word = "";
    
    public void getWord(){
        var rand = new Random();
        int r = rand.Next(wordList.Length);
        word = wordList[r];
    }
    public void loadWords(){
        wordList = File.ReadAllLines("D:\\Prog. Android\\DotNet\\rep\\wordList.txt.txt");
    }
}
public class Functions
{
    public static void welcome(){
        Console.WriteLine(" -------------------------------------------------------------- ");
        Console.WriteLine("|                                                              |");
        Console.WriteLine("|                     WELCOME TO WORDLY!!!                     |");
        Console.WriteLine("|                    ______________________                    |");
        Console.WriteLine(" -------------------------------------------------------------- ");
    }

    public static void separators(){
        int bis = 0;
        while(bis < 2){
            for(int bar = 0; bar <= 20; bar++){
                Console.Write("-");
            };
            Console.WriteLine("");
            bis++;
        };
    }

    public static void loading(){
        Console.Write("..... LOADING WORDS ");
        for(int loading = 0; loading <= 20; loading++){
            Console.Write(". ");
            System.Threading.Thread.Sleep(250);
        };
        Console.WriteLine("");
        Console.WriteLine("\nNEW GAME\n");
        Console.WriteLine("\nFind the 5 letter word in 5 atempts!!!\n".ToUpper());
    }
}
class MainClass
{
    static int Main(string[] args)
    {
        Functions.welcome();
        GlobalVar data = new GlobalVar();
        data.loadWords();
        Functions.loading();
        while(true){
            Functions.separators();
            Functions.separators();
            string compare = "";
            string displace = "";
            int temp = -1; 
            data.getWord();
            for(int atempt = 1; atempt <= 5; atempt++){
                Console.Write("\nAtempt " + atempt + ": ");
                var text = Console.ReadLine();
                if(text != null){
                    string str = text.ToLower();
                    text = str;
                } else {
                    Console.WriteLine("ERROR... SHUTING DOWN...");
                    System.Threading.Thread.Sleep(2000);
                    return 0;
                };
                if(text != null && text.Length != 5){
                    Console.WriteLine("\"" + text.ToUpper() + "\" is an invalid word. Enter a 5 letter word.\n");
                    atempt -= 1;
                } else {
                    if(text != null && text == data.word){
                        Console.WriteLine("CONGRATULATIONS!!! The word is: " + text.ToUpper() + "\n");
                        break;
                    } else {
                        for(int i = 0;i < data.word.Length;i++){
                            if(text != null && data.word[i] == text[i]){
                                compare += data.word[i] + " ";
                                temp = i;
                            } else {
                                compare += "_" + " ";
                                for(int j = 0; j < data.word.Length; j++){
                                    if(j == temp){
                                        temp = -1;
                                    } else {
                                        if(text != null && text[j] == data.word[i]){
                                            displace += text[j] + " ";
                                        };
                                    };
                                };
                            };
                        };
                        Console.WriteLine("\nMatching Letters: " + compare.ToUpper() + "\n");
                        Console.WriteLine("Displaced Letters: " + displace.ToUpper() + "\n");
                        Functions.separators();
                        displace = compare = "";
                    };
                };
            };
            Console.WriteLine("\nTOO BAD!!! The word was: " + data.word.ToUpper());
            Console.WriteLine("\n\n1 - New Game;\n2 - Exit");
            var newGame = Console.ReadLine();
            if(newGame != null && newGame != "1"){
                return 0;
            };
        };
    }
}