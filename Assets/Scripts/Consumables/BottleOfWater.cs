public class BottleOfWater : Consumable
{
    override public void GetEffect(Player player)
    {
        //���������� ����� �������� 
        player.curBullet = player.maxBullet;
        onGetEffect.Invoke();
    }
}
