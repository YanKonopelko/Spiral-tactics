public class RedFruit : Consumable
{
    // ��� ������ 1 �����
    override public void GetEffect(Player player)
    {
        Player.curRedFruitsCollect += 1;
        onGetEffect.Invoke();
    }
}
