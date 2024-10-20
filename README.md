# Sarasavi Library
This project was to develop library management system for Sarasavi, This is a desktop application developed using ASP.NET 

## Reqirements
**Project Overview.**

  Sarasavi is a popular fully stocked library with a collection of nearly 500 books. These books
  are available for loan as well as for reference by “Registered Members”, for free of charge.
  However,
  “Registered Visitors” cannot borrow any book instead they can only refer a
  book. The functions of the Sarasavi library can be categorized as below:
  Loan Process, Return Process, Reservation process, Inquiry Process, Book
  Registration Process and User Registration process

**01. Loan Process:**

  A particular book can have many copies available in the library. A Copy is a physical book
  while a Title is the class of all books which are identical, i.e. “Access 2022 all-in-one desk
  reference for dummies, by Alan Simpson, Margaret Levine Young and Alison Barrows, ISBN:
  978-0-470-03649-5” is a Title while the physical book on the bookshelf is a Copy.
  The borrower collects the copies of books that is required and hand over them to the library
  counter. The Librarian will check whether the borrower has an overdue of books to be returned
  because a borrower can borrow only maximum of 5 books from the library at a time. If the
  borrower exceeded the maximum count then they cannot borrow until the overdue books are
  returned.
  Then the Librarian will check the status of each copy which indicates whether the copy is
  “Reference” only where referenced copies are not “borrowable”. If the book is “Borrowable”
  then the loan will be confirmed and the expected return date will be informed to the borrower.
  The Librarian has the authority to accept or cancel the request for a loan and a copy of a book
  can be borrowed for a period of two weeks.

**02.Return Process:**

  The Librarian accepts the return and checks the status of the copy. If the copy is already
  reserved, the librarian takes steps to inform the member who has reserved the copy.

**03.Reservation Process:**

  On return, the reservations are checked to see if there is an outstanding reservation for the title
  a copy of which is being returned. If so, a message is displayed and the librarian puts the book
  (copy) on one side, a notification is generated for the borrower with the oldest reservation for
  the title and the oldest reservation for the title is deleted.

**04.Inquiry Process:**

  The Librarian can also handle inquiries from the borrower about the availability of a book. A
  facility is
  also available for a borrower/registered visitor to check the availability of a book. The inquiries
  may be done by knowing the specific book accession number or knowing a part or whole of the
  title or author. If it is in the catalogue, Librarian will inform the borrower the status of the book.
  The status indicates whether the book is available, referenced or not, and in the case of
  availability of multiple copies, whether all/some/no copies are loaned out, or reserved.

**05. Book Registration Process:**

  The Librarian enters the details of new books and its copies. A maximum of 10 copies are
  allowed to be registered per book number. The Librarian records the classification, book title,
  publisher, whether the copy is reference or borrowable.

  *The book number comprises*
     X 9999
     X -- Classification (1 byte classification)
     9999 -- 4 byte integer staring from 0001 for each classification
  The copy number in case of multiple copies has the same structure with an extra number
  appended at the end.

**06.User Registration Process:**

  New borrowers may also be registered. The following is captured for the user
  registration. User Number, Name, Sex, National identity card number and Address
