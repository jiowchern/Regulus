﻿Feature: ZsFormula
	In order to 接收攻擊封包開始計算
	As a math ZsHitChecker
	I want to be 回傳計算結果


Background: 魚場資料
	Given 魚場編號是1
	And 魚的資料是
	| FishId | FishOdds | FishStatus | FishType   |
	| 1      | 1        | NORMAL     | ANGEL_FISH |
		
	

Scenario:公式檢查
	Given 玩家武器資料是
	| WepId | WeaponType | WepBet | WepOdds | TotalHits | TotalHitOdds |
	| 1     | NORMAL     | 1      | 1       | 1         | 1            |

	And 亂數資料是1
	
	When 得到檢查結果
	
	Then 比對資料 fishId是1 WepId是1 DieResult是'die' Feeddack是'SUPER_BOMB' Wup是1
    
	


	
	
