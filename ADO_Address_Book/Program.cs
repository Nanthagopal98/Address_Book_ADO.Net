using ADO_Address_Book;


ManageAddressBook run = new ManageAddressBook();
Console.WriteLine("1 - To Add Data");
Console.WriteLine("2 - To Display Data");
int option = Convert.ToInt32(Console.ReadLine());
switch (option)
{
    case 1:
        run.AddData();
        break;
    case 2:
        run.display();
        break;
}



