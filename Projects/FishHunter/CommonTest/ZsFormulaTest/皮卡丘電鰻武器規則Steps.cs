﻿using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

using VGame.Project.FishHunter.Common.Data;
using VGame.Project.FishHunter.Formula.ZsFormula.Rule.FloatingOdds;

namespace GameTest.ZsFormulaTest
{
	using VGame.Project.FishHunter.Formula.ZsFormula.Rule.Weapon;

	[Binding]
	[Scope(Feature = "皮卡丘電鰻武器規則")]
	public class 皮卡丘電鰻武器規則Steps
    {
		private readonly HitRequest _HitRequest;

	    public 皮卡丘電鰻武器規則Steps()
	    {
			_HitRequest = new HitRequest();
	    }

	    [Given(@"觸發武器類型為")]
		public void Given觸發武器類型為(Table table)
		{
			_HitRequest.WeaponData = table.CreateInstance<RequestWeaponData>();
		}

		[Given(@"擊中魚清單為")]
		public void Given擊中魚清單為()
		{
			_HitRequest.FishDatas = new[]
			{
				new RequsetFishData
				{
					FishId = 1,
					FishOdds = 100,
					FishStatus = FISH_STATUS.NORMAL,
					FishType = FISH_TYPE.ANGEL_FISH,
					GraveGoods = new RequsetFishData[0]
				},
				new RequsetFishData
				{
					FishId = 2,
					FishOdds = 100,
					FishStatus = FISH_STATUS.NORMAL,
					FishType = FISH_TYPE.SPECIAL_THUNDER_BOMB,
					GraveGoods = new RequsetFishData[0]
				},
                new RequsetFishData
				{
					FishId = 2,
					FishOdds = 100,
					FishStatus = FISH_STATUS.NORMAL,
					FishType = FISH_TYPE.SPECIAL_THUNDER_BOMB,
					GraveGoods = new RequsetFishData[0]
				},
				new RequsetFishData
				{
					FishId = 2,
					FishOdds = 100,
					FishStatus = FISH_STATUS.NORMAL,
					FishType = FISH_TYPE.SPECIAL_THUNDER_BOMB,
					GraveGoods = new RequsetFishData[0]
				},
				new RequsetFishData
				{
					FishId = 2,
					FishOdds = 100,
					FishStatus = FISH_STATUS.NORMAL,
					FishType = FISH_TYPE.SPECIAL_THUNDER_BOMB,
					GraveGoods = new RequsetFishData[0]
				}
			};
		}

		[When(@"過瀘武器無效對象")]
		public void When過瀘武器無效對象()
		{
			
			var t = (new ThunderBomb() as IFilterable).Filter(_HitRequest.FishDatas);
			ScenarioContext.Current.Set(t.ToArray());
		}

		[Then(@"擊殺的魚是")]
		public void Then擊殺的魚是()
		{
			var dies = ScenarioContext.Current.Get<RequsetFishData[]>();

			Assert.AreEqual(5, dies.Count());
		}
	}
}
