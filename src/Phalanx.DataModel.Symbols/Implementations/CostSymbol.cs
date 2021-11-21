using WarHub.ArmouryModel.Source;

namespace Phalanx.DataModel.Symbols.Implementation;

public class CostSymbol : SimpleResourceEntrySymbol, ICostSymbol
{
    private readonly CostNode declaration;

    public CostSymbol(
        ICatalogueItemSymbol containingSymbol,
        CostNode declaration,
        DiagnosticBag diagnostics)
        : base(containingSymbol, declaration, diagnostics)
    {
        this.declaration = declaration;
        Type = null!; // TODO bind
    }

    public ICostTypeSymbol Type { get; }

    public decimal Value => declaration.Value;

    protected override IResourceDefinitionSymbol? BaseType => Type;
}
