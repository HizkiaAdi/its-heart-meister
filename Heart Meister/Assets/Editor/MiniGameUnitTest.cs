using System.Collections;
using UnityEngine;
using MiniGame;
using MiniGameModel;
using AttackGameLevel;
using DefenseGameLevel;
using SpeedGameLevel;
using SAttackGameLevel;
using SDefenseGameLevel;
using HealthGameLevel;
using UnityTest;
using NUnit.Framework;

public class MiniGameUnitTest
{
    [Test]
    public void AttackLevelTest()
    {
        AttackLevelManufacturer newManufacturer = new AttackLevelManufacturer();
        AttackLevelBuilder levelBuilder = null;
        levelBuilder = new AttackGameLevel.Level2();
        newManufacturer.Construct(levelBuilder);
        Assert.IsNotNull(levelBuilder.Level.Obstacle);
    }

    [Test]
    public void DefenseLevelTest()
    {
        DefenseLevelManufacturer newManufacturer = new DefenseLevelManufacturer();
        DefenseLevelBuilder levelBuilder = null;
        levelBuilder = new DefenseGameLevel.Level2();
        newManufacturer.Construct(levelBuilder);
        Assert.IsNotNull(levelBuilder.Level.Obstacle);
    }

    [Test]
    public void SpeedLevelTest()
    {
        SpeedLevelManufacturer newManufacturer = new SpeedLevelManufacturer();
        SpeedLevelBuilder levelBuilder = null;
        levelBuilder = new SpeedGameLevel.Level2();
        newManufacturer.Construct(levelBuilder);
        Assert.IsNotNull(levelBuilder.level.Spawner);
    }

    [Test]
    public void SpecialAttackLevelTest()
    {
        SAttackLevelManufacturer newManufacturer = new SAttackLevelManufacturer();
        SAttackLevelBuilder levelBuilder = null;
        levelBuilder = new SAttackGameLevel.Level2();
        newManufacturer.Construct(levelBuilder);
        Assert.IsNotNull(levelBuilder.level.Obstacle);
    }

    [Test]
    public void SpecialDefenseLevelTest()
    {
        SDefenseLevelManufacturer newManufacturer = new SDefenseLevelManufacturer();
        SDefenseLevelBuilder levelBuilder = null;
        levelBuilder = new SDefenseGameLevel.Level2();
        newManufacturer.Construct(levelBuilder);
        Assert.IsNotNull(levelBuilder.level.Obstacle);
    }

    [Test]
    public void HealthLevelTest()
    {
        HealthlevelManufacturer newManufacturer = new HealthlevelManufacturer();
        HealthLevelBuilder levelBuilder = null;
        levelBuilder = new HealthGameLevel.Level2();
        newManufacturer.Construct(levelBuilder);
        Assert.IsNotNull(levelBuilder.level.Obstacle);
    }

    [Test]
    public void PetAttributTest()
    {
        TrainingPetAttributs petInfo = TrainingPetAttributs.CreateTrainingAtributSingleton();
        ResultCalculator calculator = new ResultCalculator();
        petInfo.Level = Random.Range(1, 100);
        Assert.GreaterOrEqual(petInfo.GetTrainingLevel(), 0);
        
        petInfo.Attack = 20;
        calculator.CalculateAttack(3, 10);
        Assert.AreEqual(petInfo.Attack, 23);

        petInfo.Defense = 20;
        calculator.CalculateDefense(14);
        Assert.AreEqual(petInfo.Defense, 23);

        petInfo.Speed = 20;
        calculator.CalculateSpeed(3, 30);
        Assert.AreEqual(petInfo.Speed, 23);

        petInfo.SpecialAttack = 20;
        calculator.CalculateSpecialAttack(15);
        Assert.AreEqual(petInfo.SpecialAttack, 23);

        petInfo.SpecialDefense = 20;
        calculator.CalculateSpecialDefense(2, 3);
        Assert.AreEqual(petInfo.SpecialDefense, 23);

        petInfo.Health = 20;
        calculator.CalculateHealth(10);
        Assert.AreEqual(petInfo.Health, 23);
    }
}
