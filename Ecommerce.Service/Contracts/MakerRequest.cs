namespace Ecommerce.Service.Contracts;
public class GetMakerResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
}

public class CreateMakerRequest
{
    public string Name { get; set; }
}

public class UpdateMakerRequest
{
    public string Name { get; set; }
}

