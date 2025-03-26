내일 배움 캠프에서 하는 ATM 만들기를 해봤습니다.
천천히 공부용으로 접근한 것이라 코드가 완벽하지 않을 수 있습니다.
다만 실행은 되니!! 코드 확인도 해보시면 좋을 거같습니다!!

스크립트 설명 하겠습니다.

PopupBank - Button의 이벤트, 입출금에 대한 매서드
PopupLogin - 로그인에 대한 스크립트
DataManager - Json 저장에 대한 스크립트
Send - 송금에 대한 스크립트 
UserData - 클래스 정의
GameManager - 싱글톤 패턴을 사용하여 GameManager를 전역적으로 관리, 게임 시작 시 UI를 갱신하는 역할
UIManager -  UIManager 클래스를 통해 UI 요소(텍스트 및 입력 필드)를 관리하고, Refresh() 메서드를 사용하여 UserData 객체에 저장된 데이터를 UI에 반영하는 역할을 합니다. UserData 객체는 사용자 이름, 현금, 잔액 등을 포함하고 있으며, 이를 UI에 적절하게 표시하는 기능을 수행
signUp - 회원가입에 대한 스크립트
