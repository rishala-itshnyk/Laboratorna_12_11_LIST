namespace Laboratorna_12_11_LIST.Tests;

public class Tests
{
    [Test]
    public void AddCar_AddsCarToList()
    {
        // Arrange
        Garage garage = new Garage();
        string expectedCarNumber = "BC2006YA";

        // Act
        garage.AddCar(expectedCarNumber);

        // Assert
        Assert.AreEqual(1, garage.Cars.Count);
        Assert.AreEqual(expectedCarNumber, garage.Cars[0].Number);
    }
}