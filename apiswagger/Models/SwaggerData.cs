using apiswagger.Interfaces;

namespace apiswagger.Models
{
public class SwaggerData 
{
    public int[] numbers {get;set;}
    public SwaggerData()
    {
     numbers=new int[]{1,2,3};
    }
}
}
