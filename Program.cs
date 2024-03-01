using Azure.AI.OpenAI;
using System.IO;

namespace CSTextBook {
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            string Lang = "C#";
            Console.WriteLine("Let's work on writing a programming book with OpenAI");

            Chapter one = new Chapter{
                Title = "Starting with C#",
                Topics = {
                    new Topic{
                        Heading="What is a Programming Language", 
                        Prompt="write 2 paragraphs about what is a programming language"},
                    new Topic{
                        Heading=$"Why {Lang}", 
                        Prompt=$"Write 2 paragraphs about why {Lang} is a great programming language for a beginning programming course"},
                    new Topic{
                        Heading="What is an IDE", 
                        Prompt="write 2 paragraphs about what is an IDE"},
                    new Topic{
                        Heading="Popular IDEs for Developers", 
                        Prompt="What are 3 popular IDEs for developers"},
                    new Topic{
                        Heading="Setup a Github Account", 
                        Prompt="Explain why and How to setup a Github Account"},
                    new Topic{
                        Heading="Exercises", 
                        Prompt=$"without using a class, Create a hello world {Lang} program"}
                }
            };
            
            Chapter two = new Chapter{
                Title = "Data Types and Strings",
                Topics = {
                    new Topic{
                        Heading="Variables", 
                        Prompt="in one paragraph, explain a programming variable"},
                    new Topic{
                        Heading="Data Types", 
                        Prompt=$"what are data types in programming languages"},
                    new Topic{
                        Heading=$"Data Types in {Lang}", 
                        Prompt=$"in decreasing order, list the most commonly used data types in {Lang} and provide a description with ranges for each"},
                    new Topic{
                        Heading="String Manipulation", 
                        Prompt=$"Provide with code some examples of string manipulation in {Lang}"},
                    new Topic{
                        Heading="String Comparison", 
                        Prompt=$"Provide with code some examples of comparing strings in {Lang}"}
                }
            };
                        
            Chapter three = new Chapter{
                Title = "Conditionals and Loops",
                Topics = {
                    new Topic{
                        Heading="Types of conditionals", 
                        Prompt=$"list, explain and provide code examples for the conditionals available in {Lang}"},
                    new Topic{
                        Heading="Control Flow", 
                        Prompt="explain control flow to a beginning programmer and list the types of control flow"},
                    new Topic{
                        Heading=$"Loops in {Lang}", 
                        Prompt=$"Explain, with code examples, the different loops avaiable in {Lang}"},
                }
            };
                     
            Chapter four = new Chapter{
                Title = "Spacebar Clicker Game",
                Topics = {
                    new Topic{
                        Heading=$"Arithemetic in {Lang}", 
                        Prompt=$"Demostrate with code examples how to do arithemtic in {Lang}"},
                    new Topic{
                        Heading=$"Which Key was pressed in {Lang}", 
                        Prompt=$"Explain and Demostrate with code examples how to do determine which key was pressed in {Lang}"}                     
                }
            };
            
            Chapter five = new Chapter{
                Title = "Match the Number Sequence",
                Topics = {
                    new Topic{
                        Heading=$"Collections", 
                        Prompt=$"Write a paragraph explaining collections for an introductory programming course"},
                    new Topic{
                        Heading=$"Collections in {Lang}", 
                        Prompt=$"Discuss Lists and arrays in {Lang} and provide examples"},
                    new Topic{
                        Heading=$"Create an Array of the Alphabet", 
                        Prompt=$"Write code in {Lang} to create an array of the letters of the alphabet"},
                }
            };
            
            Chapter six = new Chapter{
                Title = "Functions",
                Topics = {
                    new Topic{
                        Heading="What are Functions", 
                        Prompt="What are functions in programming?"},
                    new Topic{
                        Heading=$"Declare a Function in {Lang}", 
                        Prompt=$"Provide an example of how to create a function in {Lang}"},
                    new Topic{
                        Heading=$"Call a Function in {Lang}", 
                        Prompt=$"Provide an example of how to call the previous function in {Lang}"},
                }
            };
            
            Chapter seven = new Chapter{
                Title = "Other Programming Languages",
                Topics = {
                    new Topic{
                        Heading=$"Why Multiple Languages", 
                        Prompt=$"Explain the purposes of having different programming languages"},
                    new Topic{
                        Heading=$"3 Other Programming Languages", 
                        Prompt=$"Compare 3 other programming languages to {Lang}"},                  
                    new Topic{
                        Heading=$"Other Programming Language Examples", 
                        Prompt=$"Write a program to accept user input and print the value 100 times in each of the 3 previous languages"},
                    new Topic{
                        Heading=$"Syntax", 
                        Prompt=$"Explain what computer programming syntax is and provide some examples compared to {Lang}"}
                }
            };
            
            Chapter eight = new Chapter{
                Title = "Object-Oriented Programming",
                Topics = {
                    new Topic{
                        Heading="What is Object-Oriented Programming",
                        Prompt="In 2 paragraphs describe Object-oriented programming"},
                    new Topic{
                        Heading="Objects vs Classes",
                        Prompt="In computer programming, what is the difference between an object and a class"},
                    new Topic{
                        Heading="Inheritence",
                        Prompt="In computer programming, what is inheritence"}
                }
            };
            
            Chapter nine = new Chapter{
                Title = "File Input and Output",
                Topics = {
                    new Topic{
                        Heading="File I/O",
                        Prompt="Write a paragraph about the importance of File IO in programming"},
                    new Topic{
                        Heading=$"Read a File in {Lang}",
                        Prompt=$"Explain and provide code examples for how to Read a File in {Lang}"},
                    new Topic{
                        Heading=$"Write a File in {Lang}",
                        Prompt=$"Explain and provide code examples for how to Write a File in {Lang}"}
                }   
            };
            
            Chapter ten = new Chapter{
                Title = "Dealing with Problems",
                Topics = {
                    new Topic{
                        Heading="Exception Handling",
                        Prompt="What is exception handling"},
                    new Topic{
                        Heading=$"Exception Handling in {Lang}",
                        Prompt=$"Provide an example of using exception handling for reading a file with {Lang}"}
                }   
            };
            
            Chapter eleven = new Chapter{
                Title = "Tracking Down Problems",
                Topics = {
                    new Topic{
                        Heading="Debugging",
                        Prompt="What is debugging"},
                    new Topic{
                        Heading="Debugging with an IDE",
                        Prompt="In 2 paragraphs, describe how debugging is related to the IDE"}
                }   
            };
                        
            List<Chapter> Chapters = new List<Chapter>{one,two,three,four,five,six,seven,eight,nine,ten,eleven};           
            
            short ChapterNum = 1;

            // create a new Directory for the Lang  
            string CleanLang = Lang.Replace("#", "-sharp").Replace("+","plus");
            Directory.CreateDirectory(CleanLang); 
            
            // write the book to file
            string BookTitle = $"A Homeschool Introduction to Programming with {Lang}";

            string Path = CleanLang + "/" + BookTitle.Replace(" ", "-").Replace("#","-Sharp").Replace("+","plus").Replace(":","") + ".md";    
            if(File.Exists(Path)) 
            {
                File.Delete(Path);
            }
            //add title details
            using(StreamWriter writer = File.AppendText(Path))
            {
                writer.WriteLine("---");
                writer.WriteLine($"title: {BookTitle}");
                writer.WriteLine("author: Ryan Swanstrom");
                writer.WriteLine($"date: {DateTime.Now.ToString("d")}");
                writer.WriteLine("---");
            }

            foreach (Chapter chap in Chapters)
            {                    
                string ChapterTitle = $"Chapter {ChapterNum}: {chap.Title}";
                ChapterNum++;
                using(StreamWriter writer = File.AppendText(Path))
                {
                    writer.WriteLine();
                    writer.WriteLine();
                    writer.WriteLine($"# {ChapterTitle}");
                    writer.WriteLine();
                    foreach (Topic t in chap.Topics)
                    {
                        Console.WriteLine($"{ChapterTitle}[{t.Heading}]");
                        writer.WriteLine();
                        writer.WriteLine();
                        writer.WriteLine($"## {t.Heading}");
                        writer.WriteLine();

                        string content = string.Empty;
                        if (!String.IsNullOrEmpty(t.Prompt)) 
                        {
                            content = await CallOpenAI(t.Prompt);
                        }
                        writer.Write(content);
                        writer.WriteLine();
                    }
                }
            }

        }

        // some good prompts 
        // please provide me 8 chapter titles for a book on an introduction to programming with C#
        // provide 3 subsection headings for the chapter: 
        // for a book about introduction to programming in C#, write 3 paragraphs about the subsection: Understanding Data Types in C#
        // 
        // 
        // 
        // 


        // run this at the command line
        // dotnet add package Azure.AI.OpenAI --prerelease
        public static async Task<string> CallOpenAI(string Prompt)
        {
            string Response = string.Empty;
        
            var AOAI_KEY = Environment.GetEnvironmentVariable("AOAI_KEY");
            OpenAIClient client = new OpenAIClient(AOAI_KEY, new OpenAIClientOptions());


                var chatCompletionsOptions = new ChatCompletionsOptions()
                {
                    Messages =
                    {
                        new ChatMessage(ChatRole.System, "You are a professional software engineer"),
                        //new ChatMessage(ChatRole.User, "Can you help me?"),
                        //new ChatMessage(ChatRole.Assistant, "Arrrr! Of course, me hearty! What can I do for ye?"),
                        new ChatMessage(ChatRole.User, Prompt),
                    },
                    Temperature = 0.0f
                };

                Azure.Response<StreamingChatCompletions> response2 = await client.GetChatCompletionsStreamingAsync(
                    deploymentOrModelName: "gpt-3.5-turbo",
                    chatCompletionsOptions);
                using StreamingChatCompletions streamingChatCompletions = response2.Value;

                await foreach (StreamingChatChoice choice in streamingChatCompletions.GetChoicesStreaming())
                {
                    await foreach (ChatMessage message in choice.GetMessageStreaming())
                    {
                        Response += message.Content;
                    }
                }


            return Response;
        }


    }

}