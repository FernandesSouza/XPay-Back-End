namespace Vanguardium.Infra.ORM.EntitiesMapping.Base;

public abstract class BaseMapping(string schema)
{
    private const string SchemaDefault = "Vanguardium";
    protected string Schema = schema;

    protected BaseMapping() : this(SchemaDefault)
    {
    }
}