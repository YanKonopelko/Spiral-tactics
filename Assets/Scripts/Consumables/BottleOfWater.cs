public class BottleOfWater : Consumable
{
    override public void GetEffect(Player player)
    {
        //Восполняет запас потронов 
        player.curBullet = player.maxBullet;
        onGetEffect.Invoke();
    }
}
