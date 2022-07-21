public class RedFruit : Consumable
{
    // Даёт игроку 1 фрукт
    override public void GetEffect(Player player)
    {
        Player.curRedFruitsCollect += 1;
        onGetEffect.Invoke();
    }
}
