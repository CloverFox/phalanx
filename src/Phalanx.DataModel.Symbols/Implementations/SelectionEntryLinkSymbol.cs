using Phalanx.DataModel.Symbols.Binding;
using WarHub.ArmouryModel.Source;

namespace Phalanx.DataModel.Symbols.Implementation;

internal class SelectionEntryLinkSymbol : SelectionEntryBaseSymbol
{
    private ISelectionEntryContainerSymbol? lazyReference;

    internal new EntryLinkNode Declaration { get; }

    public SelectionEntryLinkSymbol(
        ISymbol containingSymbol,
        EntryLinkNode declaration,
        DiagnosticBag diagnostics)
        : base(containingSymbol, declaration, diagnostics)
    {
        Declaration = declaration;
        ContainerKind = Declaration.Type switch
        {
            EntryLinkKind.SelectionEntry => ContainerEntryKind.Selection,
            EntryLinkKind.SelectionEntryGroup => ContainerEntryKind.SelectionGroup,
            _ => ContainerEntryKind.Error,
        };
        if (ContainerKind is ContainerEntryKind.Error)
        {
            diagnostics.Add(ErrorCode.ERR_UnknownEnumerationValue, Declaration);
        }
    }

    public override ContainerEntryKind ContainerKind { get; }

    public override ISelectionEntryContainerSymbol ReferencedEntry => GetBoundField(ref lazyReference);

    protected override void BindReferencesCore(Binder binder, DiagnosticBag diagnosticBag)
    {
        base.BindReferencesCore(binder, diagnosticBag);

        lazyReference = binder.BindSharedSelectionEntrySymbol(Declaration, diagnosticBag);
    }
}
