Public Class Constants
    ' 상수 정의
    Public Enum UviWarningLevel '자외선 지수 경고 레벨
        DANGEROUS = 0 '위험 (11 이상)
        VERY_HIGH '매우 높음 (8~10)
        HIGH '높음 (6~7)
        MEDIUM '보통 (3~5)
        LOW '낮음 (0~2)
    End Enum
    Public Shared _strUviWarningLevel As String() = {
      "위험",
      "매우 높음",
      "높음",
      "보통",
      "낮음"
   } '자외선 지수 경고 레벨 문자열

    Public Shared _strUviWarningLevelInfoMsg As String() = {
       "- 햇볕에 노출 시 수십 분 이내에도 피부 화상을 입을 수 있어 가장 위험함" + Environment.NewLine +
       "- 가능한 실내에 머물어야 함" + Environment.NewLine +
       "- 외출 시 긴 소매 옷, 모자, 선글라스 이용" + Environment.NewLine +
       "- 자외선 차단제를 정기적으로 발라야 함", '위험
       "- 햇볕에 노출 시 수십 분 이내에도 피부 화상을 입을 수 있어 매우 위험함" + Environment.NewLine +
       "- 오전 10시부터 오후 3시까지 외출을 피하고 실내나 그늘에 머물러야 함" + Environment.NewLine +
       "- 외출 시 긴 소매 옷, 모자, 선글라스 이용" + Environment.NewLine +
       "- 자외선 차단제를 정기적으로 발라야 함", '매우 높음
       "- 햇볕에 노출 시 1~2시간 내에도 피부 화상을 입을 수 있어 위험함" + Environment.NewLine +
       "- 한낮에는 실내나 그늘에 머물러야 함" + Environment.NewLine +
       "- 외출 시 긴 소매 옷, 모자, 선글라스 이용" + Environment.NewLine +
       "- 자외선 차단제를 정기적으로 발라야 함", '높음
       "- 햇볕에 노출 시 2~3시간 내에 피부 화상을 입을 수 있음" + Environment.NewLine +
       "- 외출 시 모자, 선글라스 이용" + Environment.NewLine +
       "- 자외선 차단제를 발라야 함", '보통
       "- 햇볕 노출에 대한 보호조치가 필요하지 않음" + Environment.NewLine +
       "- 그러나 햇볕에 민감한 피부를 가진 분은 자외선 차단제를 발라야 함" '낮음
    } '자외선 지수 경고 레벨에 따른 정보 문자열

    Public Shared _strUviWarningLevelHexBackColor As String() = {
        "#9980B7", '위험
        "#E6310F", '매우 높음
        "#F17925", '높음
        "#FDC149", '보통
        "#899ACA" '낮음
    } '자외선 지수 경고 레벨에 따른 배경색 16진수 문자열
    ''' <summary>
    ''' 자외선 지수에 따라 자외선 지수 경고 레벨 반환
    ''' </summary>
    ''' <param name="srcUvi">자외선 지수</param>
    ''' <returns>자외선 지수 경고 레벨</returns>
    Public Shared Function GetUviWarningLevelFromUvi(ByVal srcUvi As Byte) As UviWarningLevel
        If srcUvi >= 11 Then '위험 (11 이상)
            Return UviWarningLevel.DANGEROUS
        ElseIf srcUvi >= 8 Then '매우 높음 (8~10)
            Return UviWarningLevel.VERY_HIGH
        ElseIf srcUvi >= 6 Then '높음 (6~7)
            Return UviWarningLevel.HIGH
        ElseIf srcUvi >= 3 Then '보통 (3~5)
            Return UviWarningLevel.MEDIUM
        ElseIf srcUvi >= 0 Then '낮음 (0~2)
            Return UviWarningLevel.LOW
        Else
            Throw New Exception("잘못 된 자외선 지수")
        End If
    End Function
End Class
