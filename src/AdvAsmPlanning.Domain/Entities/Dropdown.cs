using System.ComponentModel.DataAnnotations.Schema;

namespace AdvAsmPlanning.Domain.Entities;

public class Dropdown : BaseEntity
{
    public Dropdown()
    {
        Children = [];
    }

    public required string Key { get; set; }
    public required string Label { get; set; }
    public required string Value { get; set; }

    [ForeignKey(nameof(Parent))]
    public long? ParentId { get; set; }
    public virtual Dropdown? Parent { get; set; }

    public virtual ICollection<Dropdown> Children { get; set; }
}
