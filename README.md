# winter_CS  
winter_DEV_Certificate Server  



스마일게이트 윈터데브 캠프 1인프로젝트  Ants 팀 설민우

최종빌드 파일 링크 :  https://drive.google.com/drive/folders/12oNIn161NBSUix2gYjNxtxN5L9yNthDP?usp=sharing  
(동작하지 않으면 서버가 내려가있는 것이니 연락주세요)  

[주제]  
인증서버 구현 및 이를 기반으로 랭킹시스탬이 있는 간단한 클리커게임 제작.  

[기술 스택]  
Unity3D  
C#  
PHP  
MYSQL(XAMPP)  
APACHE(XAMPP)  



[제공 기능]  
(백엔드)  
로그인  
회원가입  
비밀번호 암호화  
유저 데이터 갱신 및 참조  
랭킹 시스템  

(클라이언트)  
클리커 게임 시스템(클릭 획득, 자동 획득)  
상점 시스템(서버와 연결됨)  


[백엔드 구현 방법 및 이슈]  

로그인 :  users 테이블에서  입력한 username과 일치하는 항목을 찾고 그 항목의 password와 일치하면 로그인이 진행됩니다.  
암호화의 경우 SHA256을 이용하였고, 같은 비밀번호의 경후 레인보우 테이블을 통해 복원되는 것을 대비해 유저의 이름을 솔트로 포함하여 암호화를 진행합니다  
  
회원가입 : 먼저 입력받은 닉네임이 이미 있었는지 확인하고 없다면 테이블에 해싱된 패스워드와 닉네임을 삽입합니다.  

유저데이터 갱신 및 참조 : 백엔드를 포함하는 프로젝트를 처음으로 진행해봐서 PHP, Mysqle 이상을 학습할 시간은 부족하였고 JSON을 사용하지 않았습니다  
따라서 유저의 정보를 얻는 과정을 각각의 php 파일을 통해 ECHO로 보내주고, 이를 C# 스크립트 단에서 PARSE하여 인스턴스화된 변수에 삽입했습니다.  

랭킹 시스탬 : 랭킹의 경우 1위 유져의 경험치와 이름을 표기합니다. 서버단에 과부하를 막기 위해 게임이 켜질 때 + 60초마다 갱신을 실시합니다.  

// 클라이언트 단의 구성은 너무 간단해서 생략합니다.  

(핵심 이슈)  
MYSQL 데이터베이스 생성 및 XAMPP를 통한 서버 생성.  
백엔드 작업이 완전히 처음이라서 데이터베이스 생성부터 문제가 많았습니다. 특히나 언어를 몰라서 해당 정보를 어떻게 입력받아야 할지 몰랐습니다.
JSON을 사용하지 않고 변수를 입력받는 것이 초반부분의 핵심 문제였는데 www.downloadHandler.text 를 통해 ECHO를 받아올수 있다는 것을 확인하고 파싱을 이용해 사용했습니다.  
  
그 문제들중에서도 가장 어려웠던 부분은 LOCALHOST가 아닌 외부 컴퓨터에서 정보에 접속하는 부분이었는데 이를 해결하기 위해 공유기의 포트포워드 기능을 이용했습니다.  
포트포워딩을 통해 아이피를 고정시키고, 포트에 연결하여 외부에서 참조할수 있도록 WEB의 PHP 연동 파일을 변경하였습니다.  
  
  
  
[게임 동작 방식(튜토리얼)]







