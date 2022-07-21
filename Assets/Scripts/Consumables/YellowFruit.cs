public class YellowFruit : Consumable
{
    override public void GetEffect(Player player)
    {
        Player.curYellowFruitsCollect += 1;
        onGetEffect.Invoke();
    }
}
