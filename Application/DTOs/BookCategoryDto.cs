namespace Application.DTOs
{
    public record BookCategoryDto
    {
        public Guid BookId { get; set; }
        public Guid CategoryId { get; set; }
    }
}