using Phalanx.DataModel.Symbols.Binding;
using WarHub.ArmouryModel.Source;

namespace Phalanx.DataModel.Symbols.Implementation;

internal class SelectionEntryGroupSymbol : SelectionEntryBaseSymbol, ISelectionEntryGroupSymbol
{
    private ISelectionEntrySymbol? lazyDefaultEntry;

    internal new SelectionEntryGroupNode Declaration { get; }

    public SelectionEntryGroupSymbol(
        ISymbol containingSymbol,
        SelectionEntryGroupNode declaration,
        DiagnosticBag diagnostics)
        : base(containingSymbol, declaration, diagnostics)
    {
        Declaration = declaration;
    }

    public override ContainerEntryKind ContainerKind => ContainerEntryKind.SelectionGroup;

    public ISelectionEntrySymbol? DefaultSelectionEntry => GetOptionalBoundField(ref lazyDefaultEntry);

    protected override void BindReferencesCore(Binder binder, DiagnosticBag diagnosticBag)
    {
        base.BindReferencesCore(binder, diagnosticBag);

        if (Declaration.DefaultSelectionEntryId is not null)
        {
            lazyDefaultEntry = binder.BindSelectionEntryGroupDefaultEntrySymbol(Declaration, diagnosticBag);
        }
    }
}
