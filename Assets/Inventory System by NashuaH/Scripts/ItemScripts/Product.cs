using UnityEngine;

[CreateAssetMenu(fileName = "Product", menuName = "Item/Product")]

public class Product : Item
{
    public productType type;

    public override void Use()
    {
        base.Use();
    }

    public enum productType { Car, Cube, Sphere, Capsule}
}
