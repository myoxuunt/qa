﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.3623
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaiCheng
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="bcDB")]
	public partial class BcdbDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InserttblStation(tblStation instance);
    partial void UpdatetblStation(tblStation instance);
    partial void DeletetblStation(tblStation instance);
    partial void InserttblDevice(tblDevice instance);
    partial void UpdatetblDevice(tblDevice instance);
    partial void DeletetblDevice(tblDevice instance);
    partial void InserttblMeasureSluiceData(tblMeasureSluiceData instance);
    partial void UpdatetblMeasureSluiceData(tblMeasureSluiceData instance);
    partial void DeletetblMeasureSluiceData(tblMeasureSluiceData instance);
    partial void InserttblMeasureSluiceDataLast(tblMeasureSluiceDataLast instance);
    partial void UpdatetblMeasureSluiceDataLast(tblMeasureSluiceDataLast instance);
    partial void DeletetblMeasureSluiceDataLast(tblMeasureSluiceDataLast instance);
    #endregion
		
		public BcdbDataContext() : 
				base(global::BaiCheng.Properties.Settings.Default.bcDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public BcdbDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BcdbDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BcdbDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BcdbDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tblStation> tblStation
		{
			get
			{
				return this.GetTable<tblStation>();
			}
		}
		
		public System.Data.Linq.Table<tblDevice> tblDevice
		{
			get
			{
				return this.GetTable<tblDevice>();
			}
		}
		
		public System.Data.Linq.Table<tblMeasureSluiceData> tblMeasureSluiceData
		{
			get
			{
				return this.GetTable<tblMeasureSluiceData>();
			}
		}
		
		public System.Data.Linq.Table<tblMeasureSluiceDataLast> tblMeasureSluiceDataLast
		{
			get
			{
				return this.GetTable<tblMeasureSluiceDataLast>();
			}
		}
		
		public System.Data.Linq.Table<vStationDevice> vStationDevice
		{
			get
			{
				return this.GetTable<vStationDevice>();
			}
		}
		
		public System.Data.Linq.Table<vMeasureSluiceData> vMeasureSluiceData
		{
			get
			{
				return this.GetTable<vMeasureSluiceData>();
			}
		}
		
		public System.Data.Linq.Table<vMeasureSluiceDataLast> vMeasureSluiceDataLast
		{
			get
			{
				return this.GetTable<vMeasureSluiceDataLast>();
			}
		}
	}
	
	[Table(Name="dbo.tblStation")]
	public partial class tblStation : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _StationID;
		
		private string _Street;
		
		private int _StationOrdinal;
		
		private string _StationName;
		
		private string _StationRemark;
		
		private string _StationCPConfig;
		
		private EntitySet<tblDevice> _tblDevice;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnStationIDChanging(int value);
    partial void OnStationIDChanged();
    partial void OnStreetChanging(string value);
    partial void OnStreetChanged();
    partial void OnStationOrdinalChanging(int value);
    partial void OnStationOrdinalChanged();
    partial void OnStationNameChanging(string value);
    partial void OnStationNameChanged();
    partial void OnStationRemarkChanging(string value);
    partial void OnStationRemarkChanged();
    partial void OnStationCPConfigChanging(string value);
    partial void OnStationCPConfigChanged();
    #endregion
		
		public tblStation()
		{
			this._tblDevice = new EntitySet<tblDevice>(new Action<tblDevice>(this.attach_tblDevice), new Action<tblDevice>(this.detach_tblDevice));
			OnCreated();
		}
		
		[Column(Storage="_StationID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int StationID
		{
			get
			{
				return this._StationID;
			}
			set
			{
				if ((this._StationID != value))
				{
					this.OnStationIDChanging(value);
					this.SendPropertyChanging();
					this._StationID = value;
					this.SendPropertyChanged("StationID");
					this.OnStationIDChanged();
				}
			}
		}
		
		[Column(Storage="_Street", DbType="NVarChar(50)")]
		public string Street
		{
			get
			{
				return this._Street;
			}
			set
			{
				if ((this._Street != value))
				{
					this.OnStreetChanging(value);
					this.SendPropertyChanging();
					this._Street = value;
					this.SendPropertyChanged("Street");
					this.OnStreetChanged();
				}
			}
		}
		
		[Column(Storage="_StationOrdinal", DbType="Int NOT NULL")]
		public int StationOrdinal
		{
			get
			{
				return this._StationOrdinal;
			}
			set
			{
				if ((this._StationOrdinal != value))
				{
					this.OnStationOrdinalChanging(value);
					this.SendPropertyChanging();
					this._StationOrdinal = value;
					this.SendPropertyChanged("StationOrdinal");
					this.OnStationOrdinalChanged();
				}
			}
		}
		
		[Column(Storage="_StationName", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string StationName
		{
			get
			{
				return this._StationName;
			}
			set
			{
				if ((this._StationName != value))
				{
					this.OnStationNameChanging(value);
					this.SendPropertyChanging();
					this._StationName = value;
					this.SendPropertyChanged("StationName");
					this.OnStationNameChanged();
				}
			}
		}
		
		[Column(Storage="_StationRemark", DbType="NVarChar(1000)")]
		public string StationRemark
		{
			get
			{
				return this._StationRemark;
			}
			set
			{
				if ((this._StationRemark != value))
				{
					this.OnStationRemarkChanging(value);
					this.SendPropertyChanging();
					this._StationRemark = value;
					this.SendPropertyChanged("StationRemark");
					this.OnStationRemarkChanged();
				}
			}
		}
		
		[Column(Storage="_StationCPConfig", DbType="NVarChar(1000)")]
		public string StationCPConfig
		{
			get
			{
				return this._StationCPConfig;
			}
			set
			{
				if ((this._StationCPConfig != value))
				{
					this.OnStationCPConfigChanging(value);
					this.SendPropertyChanging();
					this._StationCPConfig = value;
					this.SendPropertyChanged("StationCPConfig");
					this.OnStationCPConfigChanged();
				}
			}
		}
		
		[Association(Name="tblStation_tblDevice", Storage="_tblDevice", OtherKey="StationID")]
		public EntitySet<tblDevice> tblDevice
		{
			get
			{
				return this._tblDevice;
			}
			set
			{
				this._tblDevice.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_tblDevice(tblDevice entity)
		{
			this.SendPropertyChanging();
			entity.tblStation = this;
		}
		
		private void detach_tblDevice(tblDevice entity)
		{
			this.SendPropertyChanging();
			entity.tblStation = null;
		}
	}
	
	[Table(Name="dbo.tblDevice")]
	public partial class tblDevice : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _DeviceID;
		
		private int _StationID;
		
		private string _DeviceName;
		
		private System.Nullable<int> _DeviceAddress;
		
		private string _DeviceType;
		
		private string _DeviceRemark;
		
		private string _DeviceExtend;
		
		private EntitySet<tblMeasureSluiceData> _tblMeasureSluiceData;
		
		private EntityRef<tblStation> _tblStation;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnDeviceIDChanging(int value);
    partial void OnDeviceIDChanged();
    partial void OnStationIDChanging(int value);
    partial void OnStationIDChanged();
    partial void OnDeviceNameChanging(string value);
    partial void OnDeviceNameChanged();
    partial void OnDeviceAddressChanging(System.Nullable<int> value);
    partial void OnDeviceAddressChanged();
    partial void OnDeviceTypeChanging(string value);
    partial void OnDeviceTypeChanged();
    partial void OnDeviceRemarkChanging(string value);
    partial void OnDeviceRemarkChanged();
    partial void OnDeviceExtendChanging(string value);
    partial void OnDeviceExtendChanged();
    #endregion
		
		public tblDevice()
		{
			this._tblMeasureSluiceData = new EntitySet<tblMeasureSluiceData>(new Action<tblMeasureSluiceData>(this.attach_tblMeasureSluiceData), new Action<tblMeasureSluiceData>(this.detach_tblMeasureSluiceData));
			this._tblStation = default(EntityRef<tblStation>);
			OnCreated();
		}
		
		[Column(Storage="_DeviceID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int DeviceID
		{
			get
			{
				return this._DeviceID;
			}
			set
			{
				if ((this._DeviceID != value))
				{
					this.OnDeviceIDChanging(value);
					this.SendPropertyChanging();
					this._DeviceID = value;
					this.SendPropertyChanged("DeviceID");
					this.OnDeviceIDChanged();
				}
			}
		}
		
		[Column(Storage="_StationID", DbType="Int NOT NULL")]
		public int StationID
		{
			get
			{
				return this._StationID;
			}
			set
			{
				if ((this._StationID != value))
				{
					if (this._tblStation.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnStationIDChanging(value);
					this.SendPropertyChanging();
					this._StationID = value;
					this.SendPropertyChanged("StationID");
					this.OnStationIDChanged();
				}
			}
		}
		
		[Column(Storage="_DeviceName", DbType="NVarChar(255)")]
		public string DeviceName
		{
			get
			{
				return this._DeviceName;
			}
			set
			{
				if ((this._DeviceName != value))
				{
					this.OnDeviceNameChanging(value);
					this.SendPropertyChanging();
					this._DeviceName = value;
					this.SendPropertyChanged("DeviceName");
					this.OnDeviceNameChanged();
				}
			}
		}
		
		[Column(Storage="_DeviceAddress", DbType="Int")]
		public System.Nullable<int> DeviceAddress
		{
			get
			{
				return this._DeviceAddress;
			}
			set
			{
				if ((this._DeviceAddress != value))
				{
					this.OnDeviceAddressChanging(value);
					this.SendPropertyChanging();
					this._DeviceAddress = value;
					this.SendPropertyChanged("DeviceAddress");
					this.OnDeviceAddressChanged();
				}
			}
		}
		
		[Column(Storage="_DeviceType", DbType="NVarChar(255)")]
		public string DeviceType
		{
			get
			{
				return this._DeviceType;
			}
			set
			{
				if ((this._DeviceType != value))
				{
					this.OnDeviceTypeChanging(value);
					this.SendPropertyChanging();
					this._DeviceType = value;
					this.SendPropertyChanged("DeviceType");
					this.OnDeviceTypeChanged();
				}
			}
		}
		
		[Column(Storage="_DeviceRemark", DbType="NVarChar(1000)")]
		public string DeviceRemark
		{
			get
			{
				return this._DeviceRemark;
			}
			set
			{
				if ((this._DeviceRemark != value))
				{
					this.OnDeviceRemarkChanging(value);
					this.SendPropertyChanging();
					this._DeviceRemark = value;
					this.SendPropertyChanged("DeviceRemark");
					this.OnDeviceRemarkChanged();
				}
			}
		}
		
		[Column(Storage="_DeviceExtend", DbType="NVarChar(1000)")]
		public string DeviceExtend
		{
			get
			{
				return this._DeviceExtend;
			}
			set
			{
				if ((this._DeviceExtend != value))
				{
					this.OnDeviceExtendChanging(value);
					this.SendPropertyChanging();
					this._DeviceExtend = value;
					this.SendPropertyChanged("DeviceExtend");
					this.OnDeviceExtendChanged();
				}
			}
		}
		
		[Association(Name="tblDevice_tblMeasureSluiceData", Storage="_tblMeasureSluiceData", OtherKey="DeviceID")]
		public EntitySet<tblMeasureSluiceData> tblMeasureSluiceData
		{
			get
			{
				return this._tblMeasureSluiceData;
			}
			set
			{
				this._tblMeasureSluiceData.Assign(value);
			}
		}
		
		[Association(Name="tblStation_tblDevice", Storage="_tblStation", ThisKey="StationID", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public tblStation tblStation
		{
			get
			{
				return this._tblStation.Entity;
			}
			set
			{
				tblStation previousValue = this._tblStation.Entity;
				if (((previousValue != value) 
							|| (this._tblStation.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tblStation.Entity = null;
						previousValue.tblDevice.Remove(this);
					}
					this._tblStation.Entity = value;
					if ((value != null))
					{
						value.tblDevice.Add(this);
						this._StationID = value.StationID;
					}
					else
					{
						this._StationID = default(int);
					}
					this.SendPropertyChanged("tblStation");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_tblMeasureSluiceData(tblMeasureSluiceData entity)
		{
			this.SendPropertyChanging();
			entity.tblDevice = this;
		}
		
		private void detach_tblMeasureSluiceData(tblMeasureSluiceData entity)
		{
			this.SendPropertyChanging();
			entity.tblDevice = null;
		}
	}
	
	[Table(Name="dbo.tblMeasureSluiceData")]
	public partial class tblMeasureSluiceData : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MeasureSluiceDataID;
		
		private int _DeviceID;
		
		private System.DateTime _DT;
		
		private float _BeforeWL;
		
		private float _BehindWL;
		
		private float _InstantFlux;
		
		private float _Height;
		
		private float _RemainedAmount;
		
		private float _UsedAmount;
		
		private EntitySet<tblMeasureSluiceDataLast> _tblMeasureSluiceDataLast;
		
		private EntityRef<tblDevice> _tblDevice;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMeasureSluiceDataIDChanging(int value);
    partial void OnMeasureSluiceDataIDChanged();
    partial void OnDeviceIDChanging(int value);
    partial void OnDeviceIDChanged();
    partial void OnDTChanging(System.DateTime value);
    partial void OnDTChanged();
    partial void OnBeforeWLChanging(float value);
    partial void OnBeforeWLChanged();
    partial void OnBehindWLChanging(float value);
    partial void OnBehindWLChanged();
    partial void OnInstantFluxChanging(float value);
    partial void OnInstantFluxChanged();
    partial void OnHeightChanging(float value);
    partial void OnHeightChanged();
    partial void OnRemainedAmountChanging(float value);
    partial void OnRemainedAmountChanged();
    partial void OnUsedAmountChanging(float value);
    partial void OnUsedAmountChanged();
    #endregion
		
		public tblMeasureSluiceData()
		{
			this._tblMeasureSluiceDataLast = new EntitySet<tblMeasureSluiceDataLast>(new Action<tblMeasureSluiceDataLast>(this.attach_tblMeasureSluiceDataLast), new Action<tblMeasureSluiceDataLast>(this.detach_tblMeasureSluiceDataLast));
			this._tblDevice = default(EntityRef<tblDevice>);
			OnCreated();
		}
		
		[Column(Storage="_MeasureSluiceDataID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MeasureSluiceDataID
		{
			get
			{
				return this._MeasureSluiceDataID;
			}
			set
			{
				if ((this._MeasureSluiceDataID != value))
				{
					this.OnMeasureSluiceDataIDChanging(value);
					this.SendPropertyChanging();
					this._MeasureSluiceDataID = value;
					this.SendPropertyChanged("MeasureSluiceDataID");
					this.OnMeasureSluiceDataIDChanged();
				}
			}
		}
		
		[Column(Storage="_DeviceID", DbType="Int NOT NULL")]
		public int DeviceID
		{
			get
			{
				return this._DeviceID;
			}
			set
			{
				if ((this._DeviceID != value))
				{
					if (this._tblDevice.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnDeviceIDChanging(value);
					this.SendPropertyChanging();
					this._DeviceID = value;
					this.SendPropertyChanged("DeviceID");
					this.OnDeviceIDChanged();
				}
			}
		}
		
		[Column(Storage="_DT", DbType="DateTime NOT NULL")]
		public System.DateTime DT
		{
			get
			{
				return this._DT;
			}
			set
			{
				if ((this._DT != value))
				{
					this.OnDTChanging(value);
					this.SendPropertyChanging();
					this._DT = value;
					this.SendPropertyChanged("DT");
					this.OnDTChanged();
				}
			}
		}
		
		[Column(Storage="_BeforeWL", DbType="Real NOT NULL")]
		public float BeforeWL
		{
			get
			{
				return this._BeforeWL;
			}
			set
			{
				if ((this._BeforeWL != value))
				{
					this.OnBeforeWLChanging(value);
					this.SendPropertyChanging();
					this._BeforeWL = value;
					this.SendPropertyChanged("BeforeWL");
					this.OnBeforeWLChanged();
				}
			}
		}
		
		[Column(Storage="_BehindWL", DbType="Real NOT NULL")]
		public float BehindWL
		{
			get
			{
				return this._BehindWL;
			}
			set
			{
				if ((this._BehindWL != value))
				{
					this.OnBehindWLChanging(value);
					this.SendPropertyChanging();
					this._BehindWL = value;
					this.SendPropertyChanged("BehindWL");
					this.OnBehindWLChanged();
				}
			}
		}
		
		[Column(Storage="_InstantFlux", DbType="Real NOT NULL")]
		public float InstantFlux
		{
			get
			{
				return this._InstantFlux;
			}
			set
			{
				if ((this._InstantFlux != value))
				{
					this.OnInstantFluxChanging(value);
					this.SendPropertyChanging();
					this._InstantFlux = value;
					this.SendPropertyChanged("InstantFlux");
					this.OnInstantFluxChanged();
				}
			}
		}
		
		[Column(Storage="_Height", DbType="Real NOT NULL")]
		public float Height
		{
			get
			{
				return this._Height;
			}
			set
			{
				if ((this._Height != value))
				{
					this.OnHeightChanging(value);
					this.SendPropertyChanging();
					this._Height = value;
					this.SendPropertyChanged("Height");
					this.OnHeightChanged();
				}
			}
		}
		
		[Column(Storage="_RemainedAmount", DbType="Real NOT NULL")]
		public float RemainedAmount
		{
			get
			{
				return this._RemainedAmount;
			}
			set
			{
				if ((this._RemainedAmount != value))
				{
					this.OnRemainedAmountChanging(value);
					this.SendPropertyChanging();
					this._RemainedAmount = value;
					this.SendPropertyChanged("RemainedAmount");
					this.OnRemainedAmountChanged();
				}
			}
		}
		
		[Column(Storage="_UsedAmount", DbType="Real NOT NULL")]
		public float UsedAmount
		{
			get
			{
				return this._UsedAmount;
			}
			set
			{
				if ((this._UsedAmount != value))
				{
					this.OnUsedAmountChanging(value);
					this.SendPropertyChanging();
					this._UsedAmount = value;
					this.SendPropertyChanged("UsedAmount");
					this.OnUsedAmountChanged();
				}
			}
		}
		
		[Association(Name="tblMeasureSluiceData_tblMeasureSluiceDataLast", Storage="_tblMeasureSluiceDataLast", OtherKey="MeasureSluiceDataID")]
		public EntitySet<tblMeasureSluiceDataLast> tblMeasureSluiceDataLast
		{
			get
			{
				return this._tblMeasureSluiceDataLast;
			}
			set
			{
				this._tblMeasureSluiceDataLast.Assign(value);
			}
		}
		
		[Association(Name="tblDevice_tblMeasureSluiceData", Storage="_tblDevice", ThisKey="DeviceID", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public tblDevice tblDevice
		{
			get
			{
				return this._tblDevice.Entity;
			}
			set
			{
				tblDevice previousValue = this._tblDevice.Entity;
				if (((previousValue != value) 
							|| (this._tblDevice.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tblDevice.Entity = null;
						previousValue.tblMeasureSluiceData.Remove(this);
					}
					this._tblDevice.Entity = value;
					if ((value != null))
					{
						value.tblMeasureSluiceData.Add(this);
						this._DeviceID = value.DeviceID;
					}
					else
					{
						this._DeviceID = default(int);
					}
					this.SendPropertyChanged("tblDevice");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_tblMeasureSluiceDataLast(tblMeasureSluiceDataLast entity)
		{
			this.SendPropertyChanging();
			entity.tblMeasureSluiceData = this;
		}
		
		private void detach_tblMeasureSluiceDataLast(tblMeasureSluiceDataLast entity)
		{
			this.SendPropertyChanging();
			entity.tblMeasureSluiceData = null;
		}
	}
	
	[Table(Name="dbo.tblMeasureSluiceDataLast")]
	public partial class tblMeasureSluiceDataLast : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MeasureSluiceDataLastID;
		
		private int _MeasureSluiceDataID;
		
		private int _DeviceID;
		
		private EntityRef<tblMeasureSluiceData> _tblMeasureSluiceData;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMeasureSluiceDataLastIDChanging(int value);
    partial void OnMeasureSluiceDataLastIDChanged();
    partial void OnMeasureSluiceDataIDChanging(int value);
    partial void OnMeasureSluiceDataIDChanged();
    partial void OnDeviceIDChanging(int value);
    partial void OnDeviceIDChanged();
    #endregion
		
		public tblMeasureSluiceDataLast()
		{
			this._tblMeasureSluiceData = default(EntityRef<tblMeasureSluiceData>);
			OnCreated();
		}
		
		[Column(Storage="_MeasureSluiceDataLastID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MeasureSluiceDataLastID
		{
			get
			{
				return this._MeasureSluiceDataLastID;
			}
			set
			{
				if ((this._MeasureSluiceDataLastID != value))
				{
					this.OnMeasureSluiceDataLastIDChanging(value);
					this.SendPropertyChanging();
					this._MeasureSluiceDataLastID = value;
					this.SendPropertyChanged("MeasureSluiceDataLastID");
					this.OnMeasureSluiceDataLastIDChanged();
				}
			}
		}
		
		[Column(Storage="_MeasureSluiceDataID", DbType="Int NOT NULL")]
		public int MeasureSluiceDataID
		{
			get
			{
				return this._MeasureSluiceDataID;
			}
			set
			{
				if ((this._MeasureSluiceDataID != value))
				{
					if (this._tblMeasureSluiceData.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMeasureSluiceDataIDChanging(value);
					this.SendPropertyChanging();
					this._MeasureSluiceDataID = value;
					this.SendPropertyChanged("MeasureSluiceDataID");
					this.OnMeasureSluiceDataIDChanged();
				}
			}
		}
		
		[Column(Storage="_DeviceID", DbType="Int NOT NULL")]
		public int DeviceID
		{
			get
			{
				return this._DeviceID;
			}
			set
			{
				if ((this._DeviceID != value))
				{
					this.OnDeviceIDChanging(value);
					this.SendPropertyChanging();
					this._DeviceID = value;
					this.SendPropertyChanged("DeviceID");
					this.OnDeviceIDChanged();
				}
			}
		}
		
		[Association(Name="tblMeasureSluiceData_tblMeasureSluiceDataLast", Storage="_tblMeasureSluiceData", ThisKey="MeasureSluiceDataID", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public tblMeasureSluiceData tblMeasureSluiceData
		{
			get
			{
				return this._tblMeasureSluiceData.Entity;
			}
			set
			{
				tblMeasureSluiceData previousValue = this._tblMeasureSluiceData.Entity;
				if (((previousValue != value) 
							|| (this._tblMeasureSluiceData.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tblMeasureSluiceData.Entity = null;
						previousValue.tblMeasureSluiceDataLast.Remove(this);
					}
					this._tblMeasureSluiceData.Entity = value;
					if ((value != null))
					{
						value.tblMeasureSluiceDataLast.Add(this);
						this._MeasureSluiceDataID = value.MeasureSluiceDataID;
					}
					else
					{
						this._MeasureSluiceDataID = default(int);
					}
					this.SendPropertyChanged("tblMeasureSluiceData");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.vStationDevice")]
	public partial class vStationDevice
	{
		
		private int _StationID;
		
		private string _StationName;
		
		private int _DeviceID;
		
		private string _DeviceName;
		
		private System.Nullable<int> _DeviceAddress;
		
		private string _DeviceType;
		
		private string _DeviceExtend;
		
		public vStationDevice()
		{
		}
		
		[Column(Storage="_StationID", DbType="Int NOT NULL")]
		public int StationID
		{
			get
			{
				return this._StationID;
			}
			set
			{
				if ((this._StationID != value))
				{
					this._StationID = value;
				}
			}
		}
		
		[Column(Storage="_StationName", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string StationName
		{
			get
			{
				return this._StationName;
			}
			set
			{
				if ((this._StationName != value))
				{
					this._StationName = value;
				}
			}
		}
		
		[Column(Storage="_DeviceID", DbType="Int NOT NULL")]
		public int DeviceID
		{
			get
			{
				return this._DeviceID;
			}
			set
			{
				if ((this._DeviceID != value))
				{
					this._DeviceID = value;
				}
			}
		}
		
		[Column(Storage="_DeviceName", DbType="NVarChar(255)")]
		public string DeviceName
		{
			get
			{
				return this._DeviceName;
			}
			set
			{
				if ((this._DeviceName != value))
				{
					this._DeviceName = value;
				}
			}
		}
		
		[Column(Storage="_DeviceAddress", DbType="Int")]
		public System.Nullable<int> DeviceAddress
		{
			get
			{
				return this._DeviceAddress;
			}
			set
			{
				if ((this._DeviceAddress != value))
				{
					this._DeviceAddress = value;
				}
			}
		}
		
		[Column(Storage="_DeviceType", DbType="NVarChar(255)")]
		public string DeviceType
		{
			get
			{
				return this._DeviceType;
			}
			set
			{
				if ((this._DeviceType != value))
				{
					this._DeviceType = value;
				}
			}
		}
		
		[Column(Storage="_DeviceExtend", DbType="NVarChar(1000)")]
		public string DeviceExtend
		{
			get
			{
				return this._DeviceExtend;
			}
			set
			{
				if ((this._DeviceExtend != value))
				{
					this._DeviceExtend = value;
				}
			}
		}
	}
	
	[Table(Name="dbo.vMeasureSluiceData")]
	public partial class vMeasureSluiceData
	{
		
		private int _StationID;
		
		private int _DeviceID;
		
		private int _MeasureSluiceDataID;
		
		private string _StationName;
		
		private string _DeviceName;
		
		private System.Nullable<System.DateTime> _DT;
		
		private System.Nullable<float> _BeforeWL;
		
		private System.Nullable<float> _BehindWL;
		
		private System.Nullable<float> _InstantFlux;
		
		private System.Nullable<float> _Height;
		
		private System.Nullable<float> _RemainedAmount;
		
		private System.Nullable<float> _UsedAmount;
		
		public vMeasureSluiceData()
		{
		}
		
		[Column(Storage="_StationID", DbType="Int NOT NULL")]
		public int StationID
		{
			get
			{
				return this._StationID;
			}
			set
			{
				if ((this._StationID != value))
				{
					this._StationID = value;
				}
			}
		}
		
		[Column(Storage="_DeviceID", DbType="Int NOT NULL")]
		public int DeviceID
		{
			get
			{
				return this._DeviceID;
			}
			set
			{
				if ((this._DeviceID != value))
				{
					this._DeviceID = value;
				}
			}
		}
		
		[Column(Storage="_MeasureSluiceDataID", DbType="Int NOT NULL")]
		public int MeasureSluiceDataID
		{
			get
			{
				return this._MeasureSluiceDataID;
			}
			set
			{
				if ((this._MeasureSluiceDataID != value))
				{
					this._MeasureSluiceDataID = value;
				}
			}
		}
		
		[Column(Storage="_StationName", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string StationName
		{
			get
			{
				return this._StationName;
			}
			set
			{
				if ((this._StationName != value))
				{
					this._StationName = value;
				}
			}
		}
		
		[Column(Storage="_DeviceName", DbType="NVarChar(255)")]
		public string DeviceName
		{
			get
			{
				return this._DeviceName;
			}
			set
			{
				if ((this._DeviceName != value))
				{
					this._DeviceName = value;
				}
			}
		}
		
		[Column(Storage="_DT", DbType="DateTime")]
		public System.Nullable<System.DateTime> DT
		{
			get
			{
				return this._DT;
			}
			set
			{
				if ((this._DT != value))
				{
					this._DT = value;
				}
			}
		}
		
		[Column(Storage="_BeforeWL", DbType="Real")]
		public System.Nullable<float> BeforeWL
		{
			get
			{
				return this._BeforeWL;
			}
			set
			{
				if ((this._BeforeWL != value))
				{
					this._BeforeWL = value;
				}
			}
		}
		
		[Column(Storage="_BehindWL", DbType="Real")]
		public System.Nullable<float> BehindWL
		{
			get
			{
				return this._BehindWL;
			}
			set
			{
				if ((this._BehindWL != value))
				{
					this._BehindWL = value;
				}
			}
		}
		
		[Column(Storage="_InstantFlux", DbType="Real")]
		public System.Nullable<float> InstantFlux
		{
			get
			{
				return this._InstantFlux;
			}
			set
			{
				if ((this._InstantFlux != value))
				{
					this._InstantFlux = value;
				}
			}
		}
		
		[Column(Storage="_Height", DbType="Real")]
		public System.Nullable<float> Height
		{
			get
			{
				return this._Height;
			}
			set
			{
				if ((this._Height != value))
				{
					this._Height = value;
				}
			}
		}
		
		[Column(Storage="_RemainedAmount", DbType="Real")]
		public System.Nullable<float> RemainedAmount
		{
			get
			{
				return this._RemainedAmount;
			}
			set
			{
				if ((this._RemainedAmount != value))
				{
					this._RemainedAmount = value;
				}
			}
		}
		
		[Column(Storage="_UsedAmount", DbType="Real")]
		public System.Nullable<float> UsedAmount
		{
			get
			{
				return this._UsedAmount;
			}
			set
			{
				if ((this._UsedAmount != value))
				{
					this._UsedAmount = value;
				}
			}
		}
	}
	
	[Table(Name="dbo.vMeasureSluiceDataLast")]
	public partial class vMeasureSluiceDataLast
	{
		
		private int _DeviceID;
		
		private int _MeasureSluiceDataID;
		
		private string _StationName;
		
		private string _DeviceName;
		
		private System.DateTime _DT;
		
		private float _BeforeWL;
		
		private float _BehindWL;
		
		private float _InstantFlux;
		
		private float _Height;
		
		private float _RemainedAmount;
		
		private float _UsedAmount;
		
		public vMeasureSluiceDataLast()
		{
		}
		
		[Column(Storage="_DeviceID", DbType="Int NOT NULL")]
		public int DeviceID
		{
			get
			{
				return this._DeviceID;
			}
			set
			{
				if ((this._DeviceID != value))
				{
					this._DeviceID = value;
				}
			}
		}
		
		[Column(Storage="_MeasureSluiceDataID", DbType="Int NOT NULL")]
		public int MeasureSluiceDataID
		{
			get
			{
				return this._MeasureSluiceDataID;
			}
			set
			{
				if ((this._MeasureSluiceDataID != value))
				{
					this._MeasureSluiceDataID = value;
				}
			}
		}
		
		[Column(Storage="_StationName", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string StationName
		{
			get
			{
				return this._StationName;
			}
			set
			{
				if ((this._StationName != value))
				{
					this._StationName = value;
				}
			}
		}
		
		[Column(Storage="_DeviceName", DbType="NVarChar(255)")]
		public string DeviceName
		{
			get
			{
				return this._DeviceName;
			}
			set
			{
				if ((this._DeviceName != value))
				{
					this._DeviceName = value;
				}
			}
		}
		
		[Column(Storage="_DT", DbType="DateTime NOT NULL")]
		public System.DateTime DT
		{
			get
			{
				return this._DT;
			}
			set
			{
				if ((this._DT != value))
				{
					this._DT = value;
				}
			}
		}
		
		[Column(Storage="_BeforeWL", DbType="Real NOT NULL")]
		public float BeforeWL
		{
			get
			{
				return this._BeforeWL;
			}
			set
			{
				if ((this._BeforeWL != value))
				{
					this._BeforeWL = value;
				}
			}
		}
		
		[Column(Storage="_BehindWL", DbType="Real NOT NULL")]
		public float BehindWL
		{
			get
			{
				return this._BehindWL;
			}
			set
			{
				if ((this._BehindWL != value))
				{
					this._BehindWL = value;
				}
			}
		}
		
		[Column(Storage="_InstantFlux", DbType="Real NOT NULL")]
		public float InstantFlux
		{
			get
			{
				return this._InstantFlux;
			}
			set
			{
				if ((this._InstantFlux != value))
				{
					this._InstantFlux = value;
				}
			}
		}
		
		[Column(Storage="_Height", DbType="Real NOT NULL")]
		public float Height
		{
			get
			{
				return this._Height;
			}
			set
			{
				if ((this._Height != value))
				{
					this._Height = value;
				}
			}
		}
		
		[Column(Storage="_RemainedAmount", DbType="Real NOT NULL")]
		public float RemainedAmount
		{
			get
			{
				return this._RemainedAmount;
			}
			set
			{
				if ((this._RemainedAmount != value))
				{
					this._RemainedAmount = value;
				}
			}
		}
		
		[Column(Storage="_UsedAmount", DbType="Real NOT NULL")]
		public float UsedAmount
		{
			get
			{
				return this._UsedAmount;
			}
			set
			{
				if ((this._UsedAmount != value))
				{
					this._UsedAmount = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
