namespace SberTestApi.Controllers
{
    using BusinessLogic.Services;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class FoodCostController : ControllerBase
    {
        private readonly IFoodCostCalcService foodCostCalcService;

        public FoodCostController(IFoodCostCalcService foodCostCalcService)
        {
            this.foodCostCalcService = foodCostCalcService;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(this.foodCostCalcService.ToCalc(id));
        }
    }
}
