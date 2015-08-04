﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRecordQueriers.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IRecordQueriers type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Test_Region

using System;

using Regulus.Remoting;

using VGame.Project.FishHunter.Common.Datas;

#endregion

namespace VGame.Project.FishHunter.Common.GPIs
{
	public interface IRecordQueriers
	{
		Value<Record> Load(Guid id);

		void Save(Record record);
	}
}