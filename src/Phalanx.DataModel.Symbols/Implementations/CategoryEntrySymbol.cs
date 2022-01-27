using WarHub.ArmouryModel.Source;

namespace Phalanx.DataModel.Symbols.Implementation;

internal class CategoryEntrySymbol : ContainerEntryBaseSymbol, ICategoryEntrySymbol
{
    public CategoryEntrySymbol(
        ISymbol containingSymbol,
        CategoryEntryNode declaration,
        DiagnosticBag diagnostics)
        : base(containingSymbol, declaration, diagnostics)
    {
        Declaration = declaration;
    }

    public override ContainerEntryKind ContainerKind => ContainerEntryKind.Category;

    public bool IsPrimaryCategory => false;

    public ICategoryEntrySymbol? ReferencedEntry => null;

    internal new CategoryEntryNode Declaration { get; }
}
