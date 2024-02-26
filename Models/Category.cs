using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace ShopKnjiga.Models; //napisi ; i on ce sam maknit {}, dode ti na isto

public class Category
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int DisplayOrder { get; set; }


}
