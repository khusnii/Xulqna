namespace Xulqna.Domain.Commons
{
    public class BaseResponse<TSource>
    {
        public int? Code { get; set; } = 200;
        public TSource Data { get; set; }
        public ErrorResponse Error { get; set; }
    }
}
