﻿'------------------------------------------------------------------------------
' <auto-generated>
'     이 코드는 도구를 사용하여 생성되었습니다.
'     런타임 버전:4.0.30319.42000
'
'     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
'     이러한 변경 내용이 손실됩니다.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.8.1.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings 자동 저장 기능"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        '''<summary>
        '''APi 키
        '''</summary>
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Configuration.SettingsDescriptionAttribute("APi 키"),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("zJW89pnZnfPz%2FsP%2B3Dicw9FdpysngtOm%2FBoEeeWgtYyzZlZ5NJlvb2GveKlws%2BMQBicYo1%2F"& _ 
            "9YEwRV6UZIwDzRQ%3D%3D")>  _
        Public Property apiKey() As String
            Get
                Return CType(Me("apiKey"),String)
            End Get
            Set
                Me("apiKey") = value
            End Set
        End Property
        
        '''<summary>
        '''위도, 경도에 따른 지역명 및 지역별 지점코드 엑셀 DB 파일명 (동일 경로)
        '''</summary>
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Configuration.SettingsDescriptionAttribute("위도, 경도에 따른 지역명 및 지역별 지점코드 엑셀 DB 파일명 (동일 경로)"),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("db.xlsx")>  _
        Public Property excelDbFileName() As String
            Get
                Return CType(Me("excelDbFileName"),String)
            End Get
            Set
                Me("excelDbFileName") = value
            End Set
        End Property
        
        '''<summary>
        '''위도, 경도에 따른 지역명 및 지역별 지점코드 엑셀 DB 시트명
        '''</summary>
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Configuration.SettingsDescriptionAttribute("위도, 경도에 따른 지역명 및 지역별 지점코드 엑셀 DB 시트명"),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Sheet1")>  _
        Public Property excelDbFileWorkSheetName() As String
            Get
                Return CType(Me("excelDbFileWorkSheetName"),String)
            End Get
            Set
                Me("excelDbFileWorkSheetName") = value
            End Set
        End Property
        
        '''<summary>
        '''위도, 경도에 따른 지역명 및 지역별 지점코드 엑셀 DB 파일 무결성을 위한 비밀번호
        '''</summary>
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Configuration.SettingsDescriptionAttribute("위도, 경도에 따른 지역명 및 지역별 지점코드 엑셀 DB 파일 무결성을 위한 비밀번호"),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("%mU3ZvK2lBa4KzKg9l/N@r!CK%AHf2%2A3BH#5Rk")>  _
        Public Property excelDbFilePassword() As String
            Get
                Return CType(Me("excelDbFilePassword"),String)
            End Get
            Set
                Me("excelDbFilePassword") = value
            End Set
        End Property
        
        '''<summary>
        '''사용자가 선택 한 지역의 위도
        '''</summary>
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Configuration.SettingsDescriptionAttribute("사용자가 선택 한 지역의 위도"),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property staticGeoLocationLatitude() As Double
            Get
                Return CType(Me("staticGeoLocationLatitude"),Double)
            End Get
            Set
                Me("staticGeoLocationLatitude") = value
            End Set
        End Property
        
        '''<summary>
        '''사용자가 선택 한 지역의 경도
        '''</summary>
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Configuration.SettingsDescriptionAttribute("사용자가 선택 한 지역의 경도"),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property staticGeoLocationLongitude() As Double
            Get
                Return CType(Me("staticGeoLocationLongitude"),Double)
            End Get
            Set
                Me("staticGeoLocationLongitude") = value
            End Set
        End Property
        
        '''<summary>
        '''사용자가 선택 한 지역의 드롭다운 인덱스
        '''</summary>
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Configuration.SettingsDescriptionAttribute("사용자가 선택 한 지역의 드롭다운 인덱스"),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property staticGeoLocationSelectedIndex() As String
            Get
                Return CType(Me("staticGeoLocationSelectedIndex"),String)
            End Get
            Set
                Me("staticGeoLocationSelectedIndex") = value
            End Set
        End Property
        
        '''<summary>
        '''현재 기기 위치에 따라 자동으로 지역 탐지 여부 (선택 된 지역 목록 무시)
        '''</summary>
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Configuration.SettingsDescriptionAttribute("현재 기기 위치에 따라 자동으로 지역 탐지 여부 (선택 된 지역 목록 무시)"),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property autoDetectGeoLocation() As Boolean
            Get
                Return CType(Me("autoDetectGeoLocation"),Boolean)
            End Get
            Set
                Me("autoDetectGeoLocation") = value
            End Set
        End Property
        
        '''<summary>
        '''위치 정확도
        '''</summary>
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Configuration.SettingsDescriptionAttribute("위치 정확도"),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Default")>  _
        Public Property geoPositionAccuracy() As Global.System.Device.Location.GeoPositionAccuracy
            Get
                Return CType(Me("geoPositionAccuracy"),Global.System.Device.Location.GeoPositionAccuracy)
            End Get
            Set
                Me("geoPositionAccuracy") = value
            End Set
        End Property
        
        '''<summary>
        '''최대 재시도 임계 횟수
        '''</summary>
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Configuration.SettingsDescriptionAttribute("최대 재시도 임계 횟수"),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("10")>  _
        Public Property numOfTriesThreshold() As SByte
            Get
                Return CType(Me("numOfTriesThreshold"),SByte)
            End Get
            Set
                Me("numOfTriesThreshold") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.UVI_Desktop_Notifier.My.MySettings
            Get
                Return Global.UVI_Desktop_Notifier.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace