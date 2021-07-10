using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WahooPageObject
{
    class AcuIntegrate
    {

        //public void VerifyIntegratedScenario(ref AROrder arOrderInfo, string type, IntegrationOptions options)
        //{
        //    IARTransactionForm arTrans = ARTransactionFormFactory.Construct(type);

        //    // Input the transaction on the form.
        //    Log.Information("Create transaction");
        //    arTrans.CreateTrans(ref arOrderInfo);


        //    IntegrationOptions current = options;
        //    IARTransactionForm currentDocForm = arTrans;

        //    while (current != null)
        //    {

        //        Log.Information("Form Working on ");

        //        //Verify the taxes.
        //        if (current.VerifyTaxes)
        //        {
        //            Log.Information("Verify tax Details");
        //            currentDocForm.VerifyTaxes(ref arOrderInfo);
        //        }

        //        //if Currentform needs to be posted.
        //        if (current.PostDocument)
        //        {
        //            currentDocForm.PostDocument(ref arOrderInfo, type);
        //        }

        //        // Convert to the transaction specified.
        //        if (current.ConvertDocument)
        //        {
        //            Log.Information("Convert the transaction.");

        //            IARTransactionForm convertToForm = ARTransactionFormFactory.Construct(current.ToType);

        //            currentDocForm.ConvertDocument(current.ToType, ref arOrderInfo);

        //            currentDocForm = convertToForm;
        //        }

        //        current = current.Next;
        //    }
        //}
    }
}

//public class IntegrationOptions
//{
//    /// <summary>
//    /// Transaction type to convert to.
//    /// </summary>
//    public AcuDocType ToType { get; set; }

//    /// <summary>
//    /// Determines if taxes should be verified or not.
//    /// </summary>
//    public bool VerifyTaxes { get; set; }

//    /// <summary>
//    /// Determines if the document should be converted or not.
//    /// </summary>
//    public bool ConvertDocument { get; set; }

//    /// <summary>
//    /// Determines if the document should be posted or not.
//    /// </summary>
//    public bool PostDocument { get; set; }

//    /// <summary>
//    /// Next object to convert to.
//    /// </summary>
//    public IntegrationOptions Next { get; set; }
//}

//public TestCategory SOCategory;
//public AROrder SOOrder;
//public ARConfig _ARConfigDefaults;
//public CCHSureTaxSalesConfig salesConfig;
//public CommonMethodHelper _CommonMethodHelper;

//public override void BeforeExecute()
//{
//    SOCategory = ReadXMLToClass.ReadFromXMLFile<TestCategory>(@"" + SetupAR.ARIntegrationScenarioDriver);
//}

//public override void Execute()
//{
//    foreach (TestName test in SOCategory.Test)
//    {
//        if (SetupAR.phases.Contains(test.Phase))
//        {
//            SOOrder = ReadXMLToClass.ReadFromXMLFile<AROrder>(@"" + test.FileName);
//            _ARConfigDefaults = ReadXMLToClass.ReadFromXMLFile<ARConfig>(@"" + test.Setup);
//            SOOrder.OrderType = test.OrderType;

//            using (TestExecution.CreateTestCaseGroup($"Using driver {SetupAR.ARIntegrationScenarioDriver}  Create SalesOrder - {test.OrderType} Order Type - {test.TestMethod}"))
//            {}

//using (TestExecution.CreateTestStepGroup("Integration Scernario"))
//{
//    SOOrder.OrderType = test.OrderType;
//    CommonMethod.VerifyIntegratedScenario(ref SOOrder, test.FromType, test.Options);
//}


//< TestCategory >
//  < FormName > ARForms </ FormName >
//  < Category > Tax Calculation with Integration</Category>
//  <Test>
//      <TestName>
//      <TestMethod>Integration scenario from sales Order to CreditMemo  - Tax Calc with TransTypeCode On</TestMethod>
//      <Setup>TestCases\CommonDataXML\ARConfigSO_TTTaxCalc.xml</Setup>
//      <FileName>TestCases\ARDataXML\SalesOrderTaxCalcTT.xml</FileName>
//      <Phase>1</Phase>
//      <OrderType>SO</OrderType>
//      <ToType></ToType>
//      <FromType>SalesOrder</FromType>
//      <Options>
//          <ToType>Invoice</ToType>
//          <VerifyTaxes>true</VerifyTaxes>
//          <ConvertDocument>true</ConvertDocument>
//          <PostDocument>false</PostDocument>
//          <Next>
//              <ToType>CreditMemo</ToType>
//              <VerifyTaxes>true</VerifyTaxes>
//              <ConvertDocument>true</ConvertDocument>
//              <PostDocument>true</PostDocument>
//              <Next>
//                  <VerifyTaxes>true</VerifyTaxes>
//                  <ConvertDocument>false</ConvertDocument>
//                  <PostDocument>true</PostDocument>
//              </Next>
//          </Next>
//      </Options>
//      </TestName>
//</Test>
//<Test>
//      <TestName>
//      <TestMethod>Integration scenario from sales Order to CreditMemo  - Tax Calc with TransTypeCode On</TestMethod>
//      <Setup>TestCases\CommonDataXML\ARConfigSO_TTTaxCalc.xml</Setup>
//      <FileName>TestCases\ARDataXML\SalesOrderTaxCalcTT.xml</FileName>
//      <Phase>1</Phase>
//      <OrderType>SO</OrderType>
//      <ToType></ToType>
//      <FromType>SalesOrder</FromType>
//      <Options>
//          <ToType>Invoice</ToType>
//          <VerifyTaxes>true</VerifyTaxes>
//          <ConvertDocument>true</ConvertDocument>
//          <PostDocument>false</PostDocument>
//          <Next>
//              <ToType>CreditMemo</ToType>
//              <VerifyTaxes>true</VerifyTaxes>
//              <ConvertDocument>true</ConvertDocument>
//              <PostDocument>true</PostDocument>
//              <Next>
//                  <VerifyTaxes>true</VerifyTaxes>
//                  <ConvertDocument>false</ConvertDocument>
//                  <PostDocument>true</PostDocument>
//              </Next>
//          </Next>
//      </Options>
//      </TestName>
//</Test>
//</TestCategory>
