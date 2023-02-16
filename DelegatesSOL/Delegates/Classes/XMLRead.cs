using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace Delegates.Classes
{
    public class XMLRead
    {
        public XMLRead()
        {
        }

        /*    public class Book
            {
                public String title;
            } */

        public class Catalog
        {
            // [XmlArrayItem("Book")]
            //  public List<Book> book;
            // public Book book;
            public int id { get; set; }
            public string anything { get; set; }
            public Book[] books { get; set; }
        }

        public class Book
        {
            public String author { get; set; }
            public String title { get; set; }
            public String genre { get; set; }
            public float price { get; set; }
        }

        [Serializable]
        public class Book2
        {
            public String author;
            public String title;
            public String genre;
            public String price;
            public String publish_date;
            public String description;

        }

        public class Model
        {
            public string id { get; set; }
            public ModelGroup[] model_groups { get; set; }
        }

        public class ModelGroup
        {
            public string id { get; set; }
            public string v380 { get; set; }
            public string v220 { get; set; }
            public float kw { get; set; }
            public Flow[] flows { get; set; }
        }

        public class Flow
        {
            public float m3h { get; set; }
            public float head { get; set; }
        }

        float[,] boosterPerformanceVMS8 = new float[,]
             { { 6, 7,  8,  9,  10, 11,},
          { 10, 9.3F, 9, 18.5F, 8F, 7F,},
          { 20, 19, 18, 17, 16, 14,},
          { 30, 28.5F, 27, 25, 24, 21,},
          { 41, 38, 36, 34, 32, 28,},
          { 52, 48, 45, 42, 40, 36,},
          { 62, 57, 54, 51, 48, 43,},
          { 83, 77, 73, 69, 65, 58,},
          { 104, 97, 92, 87, 81, 73,},
          { 124, 116, 111, 104, 92, 87,},
          { 145, 136, 130, 122, 113, 102,},
          { 166, 156, 148, 139, 130, 118,},
          { 187, 175, 167, 157, 146, 134,},
          { 208, 195, 186, 175, 163, 150,},};

        float[,] boosterPerformanceTest = new float[16,6];

        public void Run()
        {
            /* // First write something so that there is something to read ...  
             var b = new Book { title = "Serialization Overview" };
             var writer = new System.Xml.Serialization.XmlSerializer(typeof(Book));
             // var wfile = new System.IO.StreamWriter(@"c:\temp\SerializationOverview.xml");
             var wfile = new System.IO.StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SerializationOverview.xml"),true);
             writer.Serialize(wfile, b);
             wfile.Close(); */

            /*   // Now we can read the serialized book ...  
               System.Xml.Serialization.XmlSerializer reader =
                   new System.Xml.Serialization.XmlSerializer(typeof(Book));
               //System.IO.StreamReader file = new System.IO.StreamReader(
               //   @"c:\temp\SerializationOverview.xml");
               System.IO.StreamReader file = new System.IO.StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SerializationOverview.xml"),true);
               Book overview = (Book)reader.Deserialize(file);
               file.Close();

               Console.WriteLine(overview.title); */

            /*   System.Xml.Serialization.XmlSerializer reader2 =
                   new System.Xml.Serialization.XmlSerializer(typeof(catalog));
               //System.IO.StreamReader file = new System.IO.StreamReader(
               //   @"c:\temp\SerializationOverview.xml");
               System.IO.StreamReader fileB = new System.IO.StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"book.xml"), true);
               catalog books = (catalog)reader2.Deserialize(fileB);
               fileB.Close();

               */
            // int Fred;

            // string[] jack = { "1", "2", "3" };





            /*  List<Catalog> catalogs =
                  (
                      from e in XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"book.xml")).Root.Elements("book")
                     // from e in jack
                      select new Catalog
                      {
                          id = 1,
                          anything = (string)e.Element("author"),
                          books =
                          (
                              from p in e.Elements("author")
                             // from p in jack
                              select new Book
                              {
                                  author = "jack"
                                /*  author = (string)p.Element("author"),
                                  title = (string)p.Element("title"),
                                  genre = (string)p.Element("genre"),
                                  price = (float)p.Element("price") 
                              }).ToArray()
                      }).ToList(); */

            /* List<Book> books =
                 (
                     from p in XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"book.xml")).Root.Elements("book")
                         // from e in jack
                     select new Book
                     {

                         author = (string)p.Element("author"),
                         title = (string)p.Element("title"),
                         genre = (string)p.Element("genre"),
                         price = (float)p.Element("price"),

                     }).ToList();

             Console.WriteLine(books[1].author); */

            List<Model> models =
                (
                    from e in XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"BosterPumps.xml")).Root.Elements("model")
                    select new Model
                    {
                        id = (string)e.Element("id"),
                        model_groups =
                        (
                            from p in e.Elements("model_groups")
                            select new ModelGroup
                            {
                                id = (string)p.Element("id"),
                                v380 = (string)p.Element("v380"),
                                v220 = (string)p.Element("v220"),
                                kw = (float)p.Element("kw"),
                                flows =
                                (
                                  from r in p.Elements("flow")
                                  select new Flow
                                  {
                                      m3h = (float)r.Element("m3h"),
                                      head = (float)r.Element("head")
                                  }
                                ).ToArray()
                            }
                        ).ToArray()

                        /*  author = (string)p.Element("author"),
                          title = (string)p.Element("title"),
                          genre = (string)p.Element("genre"),
                          price = (float)p.Element("price"),*/

                    }).ToList();

            

            int pint = 0;
            int rint = 0;

            foreach (Model e in models)
            {
                foreach (ModelGroup p in e.model_groups)
                {
                    foreach (Flow r in p.flows)
                    {
                        Console.WriteLine(r.head);
                        if (pint == 0) {
                            boosterPerformanceTest[0, rint] = r.m3h;
                        }
                        boosterPerformanceTest[pint+1, rint] = r.head;
                        rint++;
                    }
                    Console.WriteLine(p.kw);
                    pint++;
                    rint = 0;
                }
                Console.WriteLine(e.model_groups[0].id);
            }

            Console.WriteLine(models[0].model_groups[0].id);

        }
            


    


    }


}