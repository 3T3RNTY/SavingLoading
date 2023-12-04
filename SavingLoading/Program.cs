using SavingLoading;
using System.Security.Cryptography.X509Certificates;

// Creating a file path
var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
var path = Path.Combine(directory, "inventory.txt");

Inventory inventory = new Inventory();



// If file exist then load all the values
if (File.Exists(path))
{
    Console.WriteLine("Here is the records...");

    Loading();
    Console.WriteLine(" Food: {0} \n Water: {1} \n Wood: {2} \n Stone: {3}",inventory.food,inventory.water, inventory.wood,inventory.stone);

    

    //A few thing to check is it working properly

    Console.WriteLine(" Press [1] to reset values... \n Press anything else to increase 10..."); 
    int desicion = Console.Read();
    if (desicion == '1')
    {
        inventory.food = 0;
        inventory.water = 0;
        inventory.wood = 0;
        inventory.stone = 0;

        Console.WriteLine(" Food: {0} \n Water: {1} \n Wood: {2} \n Stone: {3}", inventory.food, inventory.water, inventory.wood, inventory.stone);
    }
    else
    {
        inventory.food += 10;
        inventory.water += 10;
        inventory.wood += 10;
        inventory.stone += 10;

        Console.WriteLine(" Food: {0} \n Water: {1} \n Wood: {2} \n Stone: {3}", inventory.food, inventory.water, inventory.wood, inventory.stone);
    }
}

//If file not exist create a new one
else
{
    Console.WriteLine("There is no record... \n Creating a new one...");
    Saving();

}
Saving();

//Saving method
void Saving()
{
    string food = ("Food " + inventory.food + " ").ToString();
    string water = ("Water " + inventory.water + " ").ToString();
    string wood = ("Wood " + inventory.wood + " ").ToString();
    string stone = ("Stone " + inventory.stone + " ").ToString();
    string output = food + "\n" + water + "\n" + wood + "\n" + stone;

    File.WriteAllText(path, output);
}

//Loading method
void Loading()
{
    string input = File.ReadAllText(path);

    int foodValue = Convert.ToInt32(input.Split(' ')[1]);
    int waterValue = Convert.ToInt32(input.Split(' ')[3]);
    int woodValue = Convert.ToInt32(input.Split(' ')[5]);
    int stoneValue = Convert.ToInt32(input.Split(' ')[7]);

    inventory.food = foodValue;
    inventory.water = waterValue;
    inventory.wood = woodValue;
    inventory.stone = stoneValue;
}


