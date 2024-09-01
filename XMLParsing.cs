using System.Xml;

string filePath = @"C:\Users\akash\Desktop\Books.xml";
string wordsFilePath = @"C:\Users\akash\Desktop\words.xml";
string usersFilePath = @"C:\Users\akash\Desktop\users.xml";
string continentsFilePath = @"C:\Users\akash\Desktop\continents.xml";


if (File.Exists(filePath))
{
    XmlDocument doc = new XmlDocument();
    doc.Load(filePath);
    
    //Using SelectNode
    XmlNodeList bookNodes = doc.SelectNodes("/catalog/book");
    
    Console.WriteLine("Books in the library: ");
    
    foreach (XmlNode book in bookNodes)
    {
        string title = book["title"]?.InnerText;
        Console.WriteLine($"Title: {title}");
    }


    //Getting root element

    XmlElement root = doc.DocumentElement;

    foreach (XmlNode node in root.ChildNodes)
    {
        Console.WriteLine(node.Name + ": " + node.OuterXml);
    }
}
else
{
    Console.WriteLine("File doesn't exist");
}


if (File.Exists(wordsFilePath))
{
    XmlDocument doc = new XmlDocument();
    doc.Load(wordsFilePath);

    //Getting root element
    XmlElement root = doc.DocumentElement;

    //Accessing basic functions
    Console.WriteLine(root?.Name);
    Console.WriteLine(root?.FirstChild?.InnerText);
    Console.WriteLine(root?.LastChild?.InnerText);
    Console.WriteLine(root?.OuterXml);
    Console.WriteLine(root?.InnerXml);


    // Remove child node
    XmlNode userNode = root?.LastChild;
    if (userNode != null)
    {
        root.RemoveChild(userNode);
    }
    var xmlFile2 = @"C:\Users\akash\Desktop\wordsModified.xml";
    doc.Save(xmlFile2);
    

    //Creating a new element
    XmlElement e1 = doc.CreateElement("word");
    e1.InnerText = "eagle";
    root?.InsertAfter(e1, root.LastChild);

    XmlElement e2 = doc.CreateElement("word");
    e2.InnerText = "cheetah";
    root?.InsertAfter(e2, root.LastChild);

    xmlFile2 = @"C:\Users\akash\Desktop\wordsModified.xml";
    doc.Save(xmlFile2);

    // Child Nodes
    XmlNodeList childNodes = root?.ChildNodes;
    int? n = root?.ChildNodes.Count;
    
    if (childNodes != null)
    {
        foreach(XmlNode node in childNodes)
        {
            Console.WriteLine(node.InnerText);
        }
        Console.WriteLine($"There are {n} elements");
    }
}
else
{
    Console.WriteLine("File doesn't exist");
}
    

//Selecting single node
//Users.xml

if (File.Exists(usersFilePath))
{
    XmlDocument usersDoc = new XmlDocument();
    usersDoc.Load(usersFilePath);

    XmlNode node = usersDoc.SelectSingleNode($"/users/user");
    if (node != null)
    {
        var name = node.ChildNodes[0]?.InnerText;
        var occupation = node.ChildNodes[1]?.InnerText;
        var uid = node.Attributes?["id"]?.Value;

        Console.WriteLine($"Id: {uid}");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Occupation: {occupation}");
    }
    else 
    {
        Console.WriteLine("Node not found");
    }
}


if (File.Exists(continentsFilePath))
{
    XmlDocument continentsDoc = new XmlDocument();
    continentsDoc.Load(continentsFilePath);

    XmlNodeList nodes = continentsDoc.GetElementsByTagName("capital");
    Console.WriteLine("All Capitals:");

    foreach (XmlNode node in nodes)
    {
        var text = node.InnerText;
        Console.WriteLine(text);
    }

}
else
{
    Console.WriteLine("File doesn't exist");
}

//Writing a document
FileStream fs = new FileStream("products.xml", FileMode.Create);
XmlWriter w = XmlWriter.Create(fs);
w.WriteStartDocument();
w.WriteStartElement("products");

w.WriteStartElement("product");
w.WriteAttributeString("id", "1001");
w.WriteElementString("productName", "Gourmet Coffee");
w.WriteElementString("productPrice", "0.99");
w.WriteEndElement();

w.WriteStartElement("product");
w.WriteAttributeString("id", "1002");
w.WriteElementString("productName", "Tea Pot");
w.WriteElementString("productPrice", "12.99");
w.WriteEndElement();

w.WriteEndElement();
w.WriteEndDocument();
w.Flush();
fs.Close();