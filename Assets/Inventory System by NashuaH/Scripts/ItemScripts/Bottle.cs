using UnityEngine;

[CreateAssetMenu(fileName = "Bottle", menuName = "Item/Bottle")]

public class Bottle : Item
{
    public productType type;

    public override void Use()
    {
        base.Use();
    }

    public enum productType { Vine1, Vine2, Vine3, Vine4, Gin1, Gin2, Beer1, Beer2 }
}
