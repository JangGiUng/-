# -<C#으로 STACK 구현(배열 & 링크드 리스트) 및 테스트>-

배열을 이용한 스택인 stackArgs와 링크드리스트를 콜렉션을 사용하지 않고 별도로 구현한 스택인 stakcLink.

stackArgs와 stackLink를 각각 주차장에 비유해서 안에 랜덤한 번호의 자동차가 들어가도록 작동.



node 클래스=링크드 리스트에 사용하기 위한 node용 클래스. 

LinkedList 클래스=콜렉션 사용 없이 링크드리스트 구현을 위한 클래스.
-push 스택에 데이터를 집어 넣는 작업.
-pop 스택의 데이터를 삭제하는 작업.
-LinkHead 링크드리스트의 가장 앞의 데이터를 return.
-LinkTail 링크드리스트의 가장 뒤의 데이터를 return. pop 작업을 위해 이용.
-return 링크드 리스트 내부의 데이터들을 출력.


Array 클래스-배열 사용 스택 구현 클래스.
-push 스택에 데이터를 집어 넣는 작업.
-pop 스택의 데이터를 삭제하는 작업.
-arrHead 배열의 가장 앞의 데이터를 return.
-arrTail 배열의 가장 뒤의 데이터를 return. 
-return 배열 내부의 데이터들을 출력.
-leng 배열의 길이 return.


-main-

stackArgs=문자열 배열 스택.
stackList=링크드 리스트 스택.

parking=각각 스택에 무작위의 숫자를 부여해 줄 랜덤 함수.


for문으로 각각 스택에 무작위의 숫자를 10회 부여하는 push작업 실행, 각 스택에 들어가는 데이터를 출력

stackList와 stackArgs에 들어간 데이터들을 return으로 출력
출력되는 데이터들의 위에서 들어간 데이터와 동일한지 확인.

for문으로 각각 스택의 데이터를 삭제하는 pop작업 실행, stackList는 문자열 함수 key에 LinkTail로 링크드리스트의 마지막 데이터를 받아서 pop으로 해당 데이터를 삭제 지시, stackArgs는 끝에서부터 데이터를 공백으로 변경.

stackList와 stackArgs에 들어간 데이터들을 return으로 출력 
출력되는 데이터가 없다고 뜨는지 확인.

![report실행화면](https://user-images.githubusercontent.com/128966509/227825244-7d34767a-79aa-417a-8d96-6088a9d6fe55.png)


