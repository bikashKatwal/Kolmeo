
namespace Kolmeo.Entities.Dtos.Response
{
    public class ApiResult
    {
        public int ErrorNo { get; set; }
        public string Message { get; set; }

        public ApiResult(){}

        public ApiResult(int errorNo, string message)
        {
            ErrorNo = errorNo;
            Message = message;
        }
    }
}
