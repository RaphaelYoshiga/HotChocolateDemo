﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.7.0.0
//      SpecFlow Generator Version:3.7.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace RYoshiga.HotChocolateDemo.Specs
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.7.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class CustomerOrdersGraphFeature : object, Xunit.IClassFixture<CustomerOrdersGraphFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "CustomerOrdersGraph.feature"
#line hidden
        
        public CustomerOrdersGraphFeature(CustomerOrdersGraphFeature.FixtureData fixtureData, RYoshiga_HotChocolateDemo_Specs_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "", "CustomerOrdersGraph", "\tSimple calculator for adding two numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Customer with 1 order")]
        [Xunit.TraitAttribute("FeatureTitle", "CustomerOrdersGraph")]
        [Xunit.TraitAttribute("Description", "Customer with 1 order")]
        public virtual void CustomerWith1Order()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer with 1 order", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 4
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "FirstName",
                            "LastName"});
                table1.AddRow(new string[] {
                            "99",
                            "John",
                            "Bond"});
#line 5
 testRunner.Given("I am logged in as:", ((string)(null)), table1, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Total",
                            "Date"});
                table2.AddRow(new string[] {
                            "1",
                            "150",
                            "2021-01-01"});
#line 8
  testRunner.And("the customer with id 99 has placed this order", ((string)(null)), table2, "And ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "ProductId",
                            "Quantity",
                            "UnitCost",
                            "OrderId"});
                table3.AddRow(new string[] {
                            "1",
                            "2",
                            "75",
                            "1"});
#line 11
  testRunner.And("the order with id 1 has the following items", ((string)(null)), table3, "And ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Name"});
                table4.AddRow(new string[] {
                            "1",
                            "Watch"});
#line 14
  testRunner.And("the products repository contains those products", ((string)(null)), table4, "And ");
#line hidden
#line 17
 testRunner.When("I request the graph query with the orders for the current user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 18
 testRunner.Then("I should have no errors", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "FirstName",
                            "LastName"});
                table5.AddRow(new string[] {
                            "99",
                            "John",
                            "Bond"});
#line 19
  testRunner.And("I should receive this customer", ((string)(null)), table5, "And ");
#line hidden
                TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Total",
                            "Date"});
                table6.AddRow(new string[] {
                            "1",
                            "150",
                            "2021-01-01"});
#line 22
  testRunner.And("I should receive those orders", ((string)(null)), table6, "And ");
#line hidden
                TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                            "ProductId",
                            "ProductName",
                            "Quantity",
                            "UnitCost"});
                table7.AddRow(new string[] {
                            "1",
                            "Watch",
                            "2",
                            "75"});
#line 25
  testRunner.And("the order with Id 1 should contain those Items", ((string)(null)), table7, "And ");
#line hidden
#line 28
  testRunner.And("we should have called the products query only once", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Customer with 2 order")]
        [Xunit.TraitAttribute("FeatureTitle", "CustomerOrdersGraph")]
        [Xunit.TraitAttribute("Description", "Customer with 2 order")]
        public virtual void CustomerWith2Order()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer with 2 order", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 31
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "FirstName",
                            "LastName"});
                table8.AddRow(new string[] {
                            "99",
                            "John",
                            "Bond"});
#line 32
 testRunner.Given("I am logged in as:", ((string)(null)), table8, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Total",
                            "Date"});
                table9.AddRow(new string[] {
                            "1",
                            "150",
                            "2021-01-01"});
#line 35
  testRunner.And("the customer with id 99 has placed this order", ((string)(null)), table9, "And ");
#line hidden
                TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                            "ProductId",
                            "Quantity",
                            "UnitCost",
                            "OrderId"});
                table10.AddRow(new string[] {
                            "1",
                            "2",
                            "75",
                            "1"});
#line 38
  testRunner.And("the order with id 1 has the following items", ((string)(null)), table10, "And ");
#line hidden
                TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Total",
                            "Date"});
                table11.AddRow(new string[] {
                            "2",
                            "250",
                            "2021-03-01"});
#line 42
  testRunner.And("the customer with id 99 has placed this order", ((string)(null)), table11, "And ");
#line hidden
                TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                            "ProductId",
                            "Quantity",
                            "UnitCost",
                            "OrderId"});
                table12.AddRow(new string[] {
                            "2",
                            "1",
                            "225",
                            "2"});
                table12.AddRow(new string[] {
                            "3",
                            "1",
                            "25",
                            "2"});
#line 45
  testRunner.And("the order with id 2 has the following items", ((string)(null)), table12, "And ");
#line hidden
                TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Name"});
                table13.AddRow(new string[] {
                            "1",
                            "Watch"});
                table13.AddRow(new string[] {
                            "2",
                            "Monitor LCD"});
                table13.AddRow(new string[] {
                            "3",
                            "HDMI Cable"});
#line 50
  testRunner.And("the products repository contains those products", ((string)(null)), table13, "And ");
#line hidden
#line 55
 testRunner.When("I request the graph query with the orders for the current user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 56
 testRunner.Then("I should have no errors", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "FirstName",
                            "LastName"});
                table14.AddRow(new string[] {
                            "99",
                            "John",
                            "Bond"});
#line 57
  testRunner.And("I should receive this customer", ((string)(null)), table14, "And ");
#line hidden
                TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Total",
                            "Date"});
                table15.AddRow(new string[] {
                            "1",
                            "150",
                            "2021-01-01"});
                table15.AddRow(new string[] {
                            "2",
                            "250",
                            "2021-03-01"});
#line 60
  testRunner.And("I should receive those orders", ((string)(null)), table15, "And ");
#line hidden
                TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                            "ProductId",
                            "ProductName",
                            "Quantity",
                            "UnitCost"});
                table16.AddRow(new string[] {
                            "1",
                            "Watch",
                            "2",
                            "75"});
#line 64
  testRunner.And("the order with Id 1 should contain those Items", ((string)(null)), table16, "And ");
#line hidden
                TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                            "ProductId",
                            "ProductName",
                            "Quantity",
                            "UnitCost"});
                table17.AddRow(new string[] {
                            "2",
                            "Monitor LCD",
                            "1",
                            "225"});
                table17.AddRow(new string[] {
                            "3",
                            "HDMI Cable",
                            "1",
                            "25"});
#line 67
  testRunner.And("the order with Id 2 should contain those Items", ((string)(null)), table17, "And ");
#line hidden
#line 71
  testRunner.And("we should have called the products query only once", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.7.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                CustomerOrdersGraphFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                CustomerOrdersGraphFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
