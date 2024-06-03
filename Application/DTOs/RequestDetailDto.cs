namespace Application.DTOs
{
    public record RequestDetailDto
    {
        public Guid RequestId { get; set; }
        public Guid BookId { get; set; }
    }
}