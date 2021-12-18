Public Class Structures
    ' 구조체 정의
    Public Structure GeoLocationInfo '구역 정보
        Public Latitude As Double '위도
        Public Longitude As Double '경도
        Public AreaNum As String '행정구역코드 (지점코드)
        Public FullName As String '해당 구역의 전체 이름
    End Structure
    Public Structure UviApiResponseResult '자외선 지수 API 응답 결과
        Public TodayUvi As Byte '현재 시간에 대한 자외선 지수 예측 값
        Public TomorrowUvi As Byte '내일 자외선 지수 예측 값
        Public DayAfterTomorrowUvi As Byte '모레 자외선 지수 예측 값
    End Structure
End Class
