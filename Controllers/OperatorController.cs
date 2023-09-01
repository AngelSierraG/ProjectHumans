using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectHumans.Models;

namespace ProjectHumans.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Operator> PostOperator(Operator myOperators) 
        {
            switch (myOperators.myoperator) {
                
                case "+":
                    myOperators.myresult = (myOperators.value1 + myOperators.value2).ToString();

                    break;

                case "-":
                    myOperators.myresult = (myOperators.value1 - myOperators.value2).ToString();
                    break;

                case "*":
                    myOperators.myresult = (myOperators.value1 * myOperators.value2).ToString();
                    break;

                case "/":
                    if (myOperators.value2 == 0) {
                        myOperators.myresult = "No es posible dividir entre cero...";
                    }
                    else {
                    myOperators.myresult = (myOperators.value1 / myOperators.value2).ToString();
                    }
                    break;

            }

            return myOperators;
        }

        [HttpGet]
        public ActionResult<Operator> GetOperator(double value1, string myoperator, double value2)
        {
           Operator myOperatorObj = new Operator();
            switch (myoperator)
            {

                case "+":
                    myOperatorObj.myresult = (value1 + value2).ToString();
                    myOperatorObj.value1 = value1;
                    myOperatorObj.value2 = value2;
                    myOperatorObj.myoperator = myoperator;

                    break;

                case "-":
                    myOperatorObj.myresult = (value1 - value2).ToString();
                    myOperatorObj.value1 = value1;
                    myOperatorObj.value2 = value2;
                    myOperatorObj.myoperator = myoperator;
                    break;

                case "*":
                    myOperatorObj.myresult = (value1 * value2).ToString();
                    myOperatorObj.value1 = value1;
                    myOperatorObj.value2 = value2;
                    myOperatorObj.myoperator = myoperator;
                    break;

                case "/":
                    myOperatorObj.value1 = value1;
                    myOperatorObj.value2 = value2;
                    myOperatorObj.myoperator = myoperator;
                    if (myOperatorObj.value2 == 0)
                    {
                        myOperatorObj.myresult = "No es posible dividir entre cero...";
                    }
                    else
                    {
                        myOperatorObj.myresult = (value1 / value2).ToString();

                    }
                    break;

            }

            return myOperatorObj;
        }
    }

}
