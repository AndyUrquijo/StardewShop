using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class SiblingRuleTile : RuleTile
{

    public string siblingTag;

    public override bool RuleMatch(int neighbor, TileBase other)
    {
        if (other is RuleOverrideTile overrideTile)
            other = overrideTile.m_InstanceTile;

        bool tagMatch = other is SiblingRuleTile sibling && sibling.siblingTag == this.siblingTag;
        switch (neighbor)
        {
            case TilingRule.Neighbor.This: return tagMatch;
            case TilingRule.Neighbor.NotThis: return !tagMatch;
        }

        return base.RuleMatch(neighbor, other);
    }
}
