using ADO_Address_Book;


ManageAddressBook run = new ManageAddressBook();
Console.WriteLine("1 - To Add Data");
Console.WriteLine("2 - To Display Data");
Console.WriteLine("3 - To Update Data");
Console.WriteLine("4 - To Delete Person");
int option = Convert.ToInt32(Console.ReadLine());
switch (option)
{
    case 1:
        run.AddData();
        break;
    case 2:
        run.display();
        break;
    case 3:
        run.UpdateData();
        run.display();
        break;
    case 4:
        run.DeleteAddress();
        run.display();
        break;
}




