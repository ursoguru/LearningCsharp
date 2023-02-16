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
            int Fred;

            string[] jack = { "1", "2", "3" };





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

            List<Book> books =
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

            Console.WriteLine(books[1].author);

        }


    }
    
}

