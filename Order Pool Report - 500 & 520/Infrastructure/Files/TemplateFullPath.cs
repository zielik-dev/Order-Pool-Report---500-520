namespace Order_Pool_Report___500___520.Infrastructure.Files
{
    public class TemplateFullPath : ConnectionStrings
    {
        public static string Template() => String.Concat(srcTemplateDir, srcTemplateFile);
    }
}