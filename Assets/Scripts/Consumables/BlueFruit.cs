public class BlueFruit : Consumable
{
    override public void GetEffect(Player player)
    {
        Player.curBLueFruitsCollect += 1;
        onGetEffect.Invoke();
    }
}
