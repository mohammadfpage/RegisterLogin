namespace UniProject.Models.BaseDto
{
    public class ValueDto
    {
        public string Message { get; set; }
        public bool result { get; set; }
    }
    public class ValueDto<T>
    {
        public string Message { get; set; }
        public bool result { get; set; }
        public required T value { get; set; }
    }

}
